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
        public event EventHandler MigrationTargetChanged;
        public event EventHandler PendingMigrationChanged;
        public event EventHandler CompletedMigrationChanged;

        public BaseDatabaseMigrator()
        {
            Load += BaseDatabaseMigrator_Load;
        }

        private void BaseDatabaseMigrator_Load(object sender, EventArgs e)
        {
            Migrators = GetMigrators();
        }

        public TextBox LoggerTextBox
        {
            get;
            set;
        }

        public IEnumerable<DbMigrator> Migrators
        {
            get;
            private set;
        }

        public virtual void OnMigrationTargetChanged(EventArgs e)
        {
            if (MigrationTargetChanged != null)
            {
                MigrationTargetChanged(this, e);
            }
        }

        public virtual void OnPendingMigrationTargetChanged(EventArgs e)
        {
            if (PendingMigrationChanged != null)
            {
                PendingMigrationChanged(this, e);
            }
        }

        public virtual void OnCompletedMigrationChanged(EventArgs e)
        {
            if (CompletedMigrationChanged != null)
            {
                CompletedMigrationChanged(this, e);
            }
        }

        protected virtual IEnumerable<DbMigrator> GetMigrators()
        {
            Logger logger = new Logger(LoggerTextBox);

            IEnumerable<DbMigrator> migrators =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetLoadableTypes()
                where t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(typeof(IMigrationConfiguration))
                select CreateDbMigrator(t, logger);

            if (migrators == null || !migrators.Any())
            {
                logger.WriteLine("No migration configurations found");
            }

            return migrators;
        }

        protected virtual DbMigrator CreateDbMigrator(Type type, Logger logger)
        {
            DbMigrationsConfiguration dbMigrationsConfiguration = (DbMigrationsConfiguration)Activator.CreateInstance(type);

            IMigrationConfiguration migrationConfiguration = (IMigrationConfiguration)dbMigrationsConfiguration;
            migrationConfiguration.Logger = logger;
            logger.WriteLine("Found migration configuration for " + migrationConfiguration.Title);

            DbMigrator migrator = new DbMigrator(dbMigrationsConfiguration);
            return migrator;
        }
    }
}
