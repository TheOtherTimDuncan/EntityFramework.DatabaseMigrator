using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using EntityFramework.DatabaseMigrator.Migrations;

namespace EntityFramework.DatabaseMigrator
{
    public class BaseDatabaseMigrator : Form
    {
        public event MigrationTargetChangedEventHandler MigrationTargetChanged;
        public event MigrationChangedEventHandler PendingMigrationChanged;
        public event MigrationChangedEventHandler CompletedMigrationChanged;
        public event DbMigratorEventHandler MigrationCompleted;

        public BaseDatabaseMigrator()
        {
            this.Migrators = new Dictionary<string, DbMigrationsConfiguration>();

            Load += BaseDatabaseMigrator_Load;
        }

        public Logger Logger
        {
            get;
            private set;
        }

        private void BaseDatabaseMigrator_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadMigrators();

                if (Migrators.Count() > 0)
                {
                    var keyValue = Migrators.First();
                    OnMigrationTargetChanged(new MigrationTargetChangedEventArgs(keyValue.Value, keyValue.Key));
                }
            }
        }

        public TextBox LoggerTextBox
        {
            get;
            set;
        }

        public Dictionary<string, DbMigrationsConfiguration> Migrators
        {
            get;
            private set;
        }

        public virtual void OnMigrationTargetChanged(MigrationTargetChangedEventArgs e)
        {
            if (MigrationTargetChanged != null)
            {
                MigrationTargetChanged(this, e);
            }
        }

        public virtual void OnPendingMigrationTargetChanged(MigrationChangedEventArgs e)
        {
            if (PendingMigrationChanged != null)
            {
                PendingMigrationChanged(this, e);
            }
        }

        public virtual void OnCompletedMigrationChanged(MigrationChangedEventArgs e)
        {
            if (CompletedMigrationChanged != null)
            {
                CompletedMigrationChanged(this, e);
            }
        }

        public virtual void OnMigrationCompleted(DbMigratorEventArgs e)
        {
            if (MigrationCompleted != null)
            {
                MigrationCompleted(this, e);
            }
        }

        protected virtual void LoadMigrators()
        {
            Logger = new Logger(LoggerTextBox);

            IEnumerable<Type> migratorTypes =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetLoadableTypes()
                where t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(typeof(IMigrationConfiguration))
                select t;

            if (migratorTypes.Any())
            {
                foreach (Type type in migratorTypes)
                {
                    DbMigrationsConfiguration dbMigrationsConfiguration = (DbMigrationsConfiguration)Activator.CreateInstance(type);

                    IMigrationConfiguration migrationConfiguration = (IMigrationConfiguration)dbMigrationsConfiguration;
                    migrationConfiguration.Logger = Logger;
                    Logger.WriteLine("Found migration configuration for " + migrationConfiguration.Title);

                    Migrators.Add(migrationConfiguration.Title, dbMigrationsConfiguration);
                }
            }
            else
            {
                Logger.WriteLine("No migration configurations found");
            }
        }

        protected virtual DbMigrator CreateMigrator(DbMigrationsConfiguration migrationConfiguration)
        {
            return new DbMigrator(migrationConfiguration);
        }

        protected virtual MigratorBase CreateLoggingMigrator(DbMigrationsConfiguration migrationConfiguration)
        {
            return new MigratorLoggingDecorator(CreateMigrator(migrationConfiguration), Logger);
        }

        protected string GetMigrationSql(DbMigrationsConfiguration migrationConfiguration, string migrationName)
        {
            MigratorScriptingDecorator loggingScripter = new MigratorScriptingDecorator(CreateLoggingMigrator(migrationConfiguration));
            string sql = loggingScripter.ScriptUpdate(null, migrationName);
            return sql;
        }

        protected void ExecuteMigration(DbMigrationsConfiguration migrationConfiguration, string migrationName)
        {
            MigratorBase migrator = CreateLoggingMigrator(migrationConfiguration);
            migrator.Update(migrationName);
            OnMigrationCompleted(new DbMigratorEventArgs(migrationConfiguration));
        }

        protected string GetRollbackAllSql(DbMigrationsConfiguration migrationConfiguration)
        {
            MigratorScriptingDecorator loggingScripter = new MigratorScriptingDecorator(CreateLoggingMigrator(migrationConfiguration));
            string sql = loggingScripter.ScriptUpdate(null, "0");
            return sql;
        }

        protected void RollbackAll(DbMigrationsConfiguration migrationConfiguration)
        {
            MigratorBase migrator = CreateLoggingMigrator(migrationConfiguration);
            migrator.Update("0");
            OnMigrationCompleted(new DbMigratorEventArgs(migrationConfiguration));
        }

        protected void Reseed(DbMigrationsConfiguration migrationConfiguration)
        {
            // I would rather not use reflection for this but the alternatives look to be even worse
            // Sticking with the lesser evil for now

            MigratorBase migrator = CreateMigrator(migrationConfiguration);
            MethodInfo method = migrator.GetType().GetMethod("SeedDatabase", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(migrator, null);
        }

        protected string GetMigrationHistory(DbMigrationsConfiguration migrationConfiguration, string migrationName)
        {
            // I would rather not use reflection to get the needed DbConnection but the alternative is requiring 
            // more configuraton or hardcoding to SQL Server. This looks to be the lesser of multiple evils

            MigratorBase migrator = CreateMigrator(migrationConfiguration);
            MethodInfo method = migrator.GetType().GetMethod("CreateConnection", BindingFlags.NonPublic | BindingFlags.Instance);

            using (DbConnection dbConnection = (DbConnection)method.Invoke(migrator, null))
            {
                dbConnection.Open();

                using (HistoryContext historyContext = new HistoryContext(dbConnection, null))
                {
                    HistoryRow history = historyContext.History.SingleOrDefault(x => x.MigrationId == migrationName);
                    if (history != null)
                    {
                        using (MemoryStream stream = new MemoryStream(history.Model))
                        {
                            using (GZipStream gzip = new GZipStream(stream, CompressionMode.Decompress))
                            {
                                return XDocument.Load(gzip).ToString();
                            }
                        }
                    }
                    else
                    {
                        return "Migration name not found";
                    }
                }
            }
        }
    }
}
