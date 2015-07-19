using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void DbMigratorEventHandler(object sender, DbMigratorEventArgs e);

    public class DbMigratorEventArgs : EventArgs
    {
        public DbMigratorEventArgs(DbMigrationsConfiguration migrationConfiguration)
        {
            this.MigrationConfiguration = migrationConfiguration;

            DbMigrator migrator = new DbMigrator(migrationConfiguration);
            this.PendingMigrations = migrator.GetPendingMigrations();
            this.CompletedMigrations = migrator.GetDatabaseMigrations();
        }

        public DbMigrationsConfiguration MigrationConfiguration
        {
            get;
            set;
        }

        public IEnumerable<string> PendingMigrations
        {
            get;
            private set;
        }

        public IEnumerable<string> CompletedMigrations
        {
            get;
            set;
        }
    }
}
