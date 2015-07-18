using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EntityFramework.DatabaseMigrator.Migrations;

namespace EntityFramework.DatabaseMigrator
{
    public class BaseDatabaseMigrator : Form
    {
        public event DbMigratorEventHandler MigrationTargetChanged;
        public event DbMigratorEventHandler PendingMigrationChanged;
        public event DbMigratorEventHandler CompletedMigrationChanged;

        public BaseDatabaseMigrator()
        {
            this.Migrators = new Dictionary<string, DbMigrator>();

            Load += BaseDatabaseMigrator_Load;
        }

        private void BaseDatabaseMigrator_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadMigrators();
            }
        }

        public TextBox LoggerTextBox
        {
            get;
            set;
        }

        public Dictionary<string,DbMigrator> Migrators
        {
            get;
            private set;
        }

        public virtual void OnMigrationTargetChanged(DbMigratorEventArgs e)
        {
            if (MigrationTargetChanged != null)
            {
                MigrationTargetChanged(this, e);
            }
        }

        public virtual void OnPendingMigrationTargetChanged(DbMigratorEventArgs e)
        {
            if (PendingMigrationChanged != null)
            {
                PendingMigrationChanged(this, e);
            }
        }

        public virtual void OnCompletedMigrationChanged(DbMigratorEventArgs e)
        {
            if (CompletedMigrationChanged != null)
            {
                CompletedMigrationChanged(this, e);
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
                    Migrators.Add(migrationConfiguration.Title, migrator);
                }
            }
            else
            {
                logger.WriteLine("No migration configurations found");
            }
        }
    }
}
