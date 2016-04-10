using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void ConnectionStringChangedEventHandler(object sender, ConnectionStringChangedEventArgs e);

    public class ConnectionStringChangedEventArgs : DbMigratorEventArgs
    {
        public ConnectionStringChangedEventArgs(DbMigrationsConfiguration migrationConfiguration, ConnectionStringSettings setting)
            : base(migrationConfiguration)
        {
            this.ConnectionStringSetting = setting;
        }

        public ConnectionStringSettings ConnectionStringSetting
        {
            get;
            set;
        }
    }
}
