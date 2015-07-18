using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void DbMigratorEventHandler(object sender, DbMigratorEventArgs e);

    public class DbMigratorEventArgs : EventArgs
    {
        public DbMigratorEventArgs(DbMigrator migrator)
        {
            this.Migrator = migrator;
        }

        public DbMigrator Migrator
        {
            get;
            private set;
        }
    }
}
