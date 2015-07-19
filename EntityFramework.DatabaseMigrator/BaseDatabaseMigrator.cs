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
            this.Migrators = new Dictionary<string, MigratorLoggingDecorator>();

            Load += BaseDatabaseMigrator_Load;
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

        public Dictionary<string, MigratorLoggingDecorator> Migrators
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
            Logger logger = new Logger(LoggerTextBox);

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
                    migrationConfiguration.Logger = logger;
                    logger.WriteLine("Found migration configuration for " + migrationConfiguration.Title);

                    DbMigrator migrator = new DbMigrator(dbMigrationsConfiguration);
                    Migrators.Add(migrationConfiguration.Title, new MigratorLoggingDecorator(migrator, logger));
                }
            }
            else
            {
                logger.WriteLine("No migration configurations found");
            }
        }

        protected string GetMigrationSql(MigratorLoggingDecorator migrator, string migrationName)
        {
            MigratorScriptingDecorator loggingScripter = new MigratorScriptingDecorator(migrator);
            string sql = loggingScripter.ScriptUpdate(null, migrationName);
            return sql;
        }

        protected void ExecuteMigration(MigratorLoggingDecorator migrator, string migrationName)
        {
            migrator.Update(migrationName);
            OnMigrationCompleted(new DbMigratorEventArgs(migrator));
        }

        protected string GetRollbackAllSql(MigratorLoggingDecorator migrator)
        {
            MigratorScriptingDecorator loggingScripter = new MigratorScriptingDecorator(migrator);
            string sql = loggingScripter.ScriptUpdate(null, "0");
            return sql;
        }

        protected void RollbackAll(MigratorLoggingDecorator migrator)
        {
            migrator.Update("0");
            OnMigrationCompleted(new DbMigratorEventArgs(migrator));
        }

        protected void Reseed(MigratorLoggingDecorator migrator)
        {
            // I would rather not use reflection for this but the alternatives look to be even worse
            // Sticking with the lesser evil for now

            // Since the decorator wraps the DbMigrator we first have to get the underling DbMigrator
            FieldInfo field = migrator.GetType().BaseType.GetField("_this", BindingFlags.NonPublic | BindingFlags.Instance);
            object fieldValue = field.GetValue(migrator);

            // Now we can get the method we need to seed the database and invoke it
            MethodInfo method = fieldValue.GetType().GetMethod("SeedDatabase", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(fieldValue, null);
        }

        protected string GetMigrationHistory(MigratorLoggingDecorator migrator, string migrationName)
        {
            // I would rather not use reflection to get the needed DbConnection but the alternative is requiring 
            // more configuraton or hardcoding to SQL Server. This looks to be the lesser of multiple evils

            // Since the decorator wraps the DbMigrator we first have to get the underling DbMigrator
            FieldInfo field = migrator.GetType().BaseType.GetField("_this", BindingFlags.NonPublic | BindingFlags.Instance);
            object fieldValue = field.GetValue(migrator);

            // Now we can get the method we need to create the DbConnection
            MethodInfo method = fieldValue.GetType().GetMethod("CreateConnection", BindingFlags.NonPublic | BindingFlags.Instance);

            using (DbConnection dbConnection = (DbConnection)method.Invoke(fieldValue, null))
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
