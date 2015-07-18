using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void DbMigratorEventHandler(object sender, DbMigratorEventArgs e);

    public class DbMigratorEventArgs : EventArgs
    {
        public DbMigratorEventArgs(MigratorLoggingDecorator migrator, string migratorTitle)
        {
            this.Migrator = migrator;
            this.MigratorTitle = migratorTitle;
        }

        public MigratorLoggingDecorator Migrator
        {
            get;
            private set;
        }

        public string MigratorTitle
        {
            get;
            private set;
        }
    }
}
