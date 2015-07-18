using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void MigrationTargetChangedEventHandler(object sender, MigrationTargetChangedEventArgs e);

    public class MigrationTargetChangedEventArgs : DbMigratorEventArgs
    {
        public MigrationTargetChangedEventArgs(DbMigrator migrator, string migratorTitle)
            : base(migrator, migratorTitle)
        {
            PendingMigrations = migrator.GetPendingMigrations();
            CompletedMigrations = migrator.GetDatabaseMigrations();
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
