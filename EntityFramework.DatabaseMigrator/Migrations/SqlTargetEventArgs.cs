using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.DatabaseMigrator.Migrations
{
    public delegate void SqlTargetEventHandler(object sender, SqlTargetEventArgs e);

    public class SqlTargetEventArgs : EventArgs
    {
        public SqlTargetEventArgs(string target)
        {
            this.Target = target;
        }

        public string Target
        {
            get;
            set;
        }
    }
}
