using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void MigrationTargetChangedEventHandler(object sender, MigrationTargetChangedEventArgs e);

    public class MigrationTargetChangedEventArgs : DbMigratorEventArgs
    {
        public MigrationTargetChangedEventArgs(MigratorLoggingDecorator migrator, string migratorTitle)
            : base(migrator)
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
