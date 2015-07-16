using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityFramework.DatabaseMigrator.Example.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs
        {
            get;
            set;
        }
    }
}
