using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EntityFramework.DatabaseMigrator
{
    public class BaseDatabaseMigrator : Form
    {
        public event EventHandler MigrationTargetChanged;
        public event EventHandler PendingMigrationChanged;
        public event EventHandler CompletedMigrationChanged;

        public virtual void OnMigrationTargetChanged(EventArgs e)
        {
            if (MigrationTargetChanged != null)
            {
                MigrationTargetChanged(this, e);
            }
        }

        public virtual void OnPendingMigrationTargetChanged(EventArgs e)
        {
            if (PendingMigrationChanged != null)
            {
                PendingMigrationChanged(this, e);
            }
        }

        public virtual void OnCompletedMigrationChanged(EventArgs e)
        {
            if (CompletedMigrationChanged != null)
            {
                CompletedMigrationChanged(this, e);
            }
        }
    }
}
