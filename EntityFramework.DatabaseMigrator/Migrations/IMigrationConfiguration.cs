using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Infrastructure;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public interface IMigrationConfiguration
    {
        MigrationsLogger Logger
        {
            get;
            set;
        }

        string Title
        {
            get;
        }
    }
}
