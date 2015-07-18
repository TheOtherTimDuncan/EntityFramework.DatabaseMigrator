using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void DbMigratorEventHandler(object sender, DbMigratorEventArgs e);

    public class DbMigratorEventArgs : EventArgs
    {
        public DbMigratorEventArgs(MigratorLoggingDecorator migrator)
        {
            this.Migrator = migrator;
            this.PendingMigrations = migrator.GetPendingMigrations();
            this.CompletedMigrations = migrator.GetDatabaseMigrations();
        }

        public MigratorLoggingDecorator Migrator
        {
            get;
            private set;
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
