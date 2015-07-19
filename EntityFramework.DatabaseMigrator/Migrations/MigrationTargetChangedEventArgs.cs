using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void MigrationTargetChangedEventHandler(object sender, MigrationTargetChangedEventArgs e);

    public class MigrationTargetChangedEventArgs : DbMigratorEventArgs
    {
        public MigrationTargetChangedEventArgs(DbMigrationsConfiguration migrationConfiguration, string migratorTitle)
            : base(migrationConfiguration)
        {
            MigratorTitle = migratorTitle;
        }

        public string MigratorTitle
        {
            get;
            private set;
        }
    }
}
