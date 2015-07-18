using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFramework.DatabaseMigrator.Migrations;

namespace EntityFramework.DatabaseMigrator
{
    public partial class DatabaseMigrator : BaseDatabaseMigrator
    {
        private DbMigrator _currentMigrator;
        private string _currentMigratorTitle;
        private string _currentPending;
        private string _currentCompleted;

        public DatabaseMigrator()
            : base()
        {
            InitializeComponent();

            LoggerTextBox = txtLog;

            MigrationTargetChanged += DatabaseMigrator_MigrationTargetChanged;
        }

        protected override void LoadMigrators()
        {
            base.LoadMigrators();

            if (Migrators.Count() > 1)
            {
                lblMigrationTarget.Visible = false;

                cmbMigrationTarget.Visible = true;
                cmbMigrationTarget.DataSource = new BindingSource(Migrators, null);
                cmbMigrationTarget.DisplayMember = "Key";
                cmbMigrationTarget.ValueMember = "Key";
            }
            else if (Migrators.Count() == 1)
            {
                cmbMigrationTarget.Visible = false;
                lblMigrationTarget.Visible = true;
            }
        }

        private void DatabaseMigrator_MigrationTargetChanged(object sender, MigrationTargetChangedEventArgs e)
        {
            _currentMigrator = e.Migrator;
            _currentMigratorTitle = e.MigratorTitle;

            lblMigrationTarget.Text = e.MigratorTitle;
            cmbMigrationTarget.SelectedText = e.MigratorTitle;

            lbPending.DataSource = e.PendingMigrations;
            btnMigrateSql.Enabled = e.PendingMigrations.Any();
            btnMigrate.Enabled = btnMigrateSql.Enabled;

            lbCompleted.DataSource = e.CompletedMigrations;
            btnRollbackSql.Enabled = e.CompletedMigrations.Any();
            btnRollback.Enabled = btnRollbackSql.Enabled;
            btnMigrationHistory.Enabled = btnRollbackSql.Enabled;
        }

        private void lbPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPending = (string)lbPending.SelectedItem;
            btnMigrateSql.Text = "View Sql For Migration To " + _currentPending;
            btnMigrate.Text = "Migrate to " + _currentPending;

            OnPendingMigrationTargetChanged(new MigrationChangedEventArgs(_currentMigrator, _currentMigratorTitle, _currentPending));
        }

        private void lbCompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCompleted = (string)lbCompleted.SelectedItem;
            btnRollbackSql.Text = "View Sql For Rollback To " + _currentCompleted;
            btnRollback.Text = "Rollback to " + _currentCompleted;
            btnMigrationHistory.Text = "View Migration History For " + _currentCompleted;

            OnCompletedMigrationChanged(new MigrationChangedEventArgs(_currentMigrator, _currentMigratorTitle, _currentPending));

        }
    }
}
