using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Reflection;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public class BaseMigrationConfiguration<TContext> : DbMigrationsConfiguration<TContext>, IMigrationConfiguration where TContext : DbContext
    {
        public MigrationsLogger Logger
        {
            get;
            set;
        }

        public virtual string Title
        {
            get
            {
                return typeof(TContext).Name;
            }
        }
    }
}
