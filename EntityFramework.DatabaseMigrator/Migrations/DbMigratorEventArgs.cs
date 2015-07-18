using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void DbMigratorEventHandler(object sender, DbMigratorEventArgs e);

    public class DbMigratorEventArgs : EventArgs
    {
        public DbMigratorEventArgs(DbMigrator migrator, string migratorTitle)
        {
            this.Migrator = migrator;
            this.MigratorTitle = migratorTitle;
        }

        public DbMigrator Migrator
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
