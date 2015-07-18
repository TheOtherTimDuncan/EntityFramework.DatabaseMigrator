using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void MigrationChangedEventHandler(object sender, MigrationChangedEventArgs e);

    public class MigrationChangedEventArgs : DbMigratorEventArgs
    {
        public MigrationChangedEventArgs(MigratorLoggingDecorator migrator, string migrationName)
            : base(migrator)
        {
            this.MigrationName = migrationName;
        }

        public string MigrationName
        {
            get;
            private set;
        }
    }
}
