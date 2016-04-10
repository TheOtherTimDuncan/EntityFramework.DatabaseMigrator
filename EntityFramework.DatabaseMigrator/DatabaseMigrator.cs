using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EntityFramework.DatabaseMigrator.Migrations;

namespace EntityFramework.DatabaseMigrator
{
    public partial class DatabaseMigrator : BaseDatabaseMigrator
    {
        private DbMigrationsConfiguration _currentConfiguration;
        private string _currentPending;
        private string _currentCompleted;
        private string _currentSqlTarget;

        protected const string SQL_TARGET_CONSOLE = "Console";
        protected const string SQL_TARGET_FILE = "File";

        public DatabaseMigrator()
            : base()
        {
            InitializeComponent();

            LoggerTextBox = txtConsole;

            MigrationTargetChanged += DatabaseMigrator_MigrationTargetChanged;
            MigrationCompleted += DatabaseMigrator_MigrationCompleted;
            SqlTargetChanged += DatabaseMigrator_SqlTargetChanged;
            ConnectionStringChanged += DatabaseMigrator_ConnectionStringChanged;

            cmbSqlTarget.Items.AddRange(new[] { SQL_TARGET_CONSOLE, SQL_TARGET_FILE });
            _currentSqlTarget = SQL_TARGET_CONSOLE;
            cmbSqlTarget.Text = _currentSqlTarget;
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
                cmbMigrationTarget.SelectedIndexChanged += cmbMigrationTarget_SelectedIndexChanged;
            }
            else if (Migrators.Count() == 1)
            {
                cmbMigrationTarget.Visible = false;
                lblMigrationTarget.Visible = true;
            }

            if (ConnectionStrings.Count() > 1)
            {
                lblConnectionString.Visible = false;

                cmbConnectionString.Visible = true;
                cmbConnectionString.Items.AddRange(ConnectionStrings.Select(x => x.Name).ToArray());
                cmbConnectionString.SelectedIndexChanged += cmbConnectionString_SelectedIndexChanged;
                cmbConnectionString.Text = ConnectionStrings.First().Name;
            }
            else
            {
                lblConnectionString.Visible = true;
                cmbConnectionString.Visible = false;
                lblConnectionString.Text = GetConnectionStringDisplay(ConnectionStrings.Single());
            }
        }

        private void UpdateMigrationLists(DbMigratorEventArgs e)
        {
            lbPending.DataSource = e.PendingMigrations;
            btnMigrateSql.Enabled = e.PendingMigrations.Any();
            btnMigrate.Enabled = btnMigrateSql.Enabled;

            lbCompleted.DataSource = e.CompletedMigrations;
            btnRollbackSql.Enabled = e.CompletedMigrations.Any();
            btnRollback.Enabled = btnRollbackSql.Enabled;
            btnMigrationHistory.Enabled = btnRollbackSql.Enabled;
        }

        private void SetMigrateSqlText()
        {
            btnMigrateSql.Text = "Get Sql For Migration To " + _currentPending + " To " + _currentSqlTarget;
        }

        private string GetConnectionStringDisplay(ConnectionStringSettings setting)
        {
            return setting.Name + " (" + setting.ConnectionString + ")";
        }

        private void HandleSql(string sql)
        {
            Logger.WriteLine();

            if (_currentSqlTarget == SQL_TARGET_CONSOLE)
            {
                Logger.WriteLine(sql);
            }
            else
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.DefaultExt = "sql";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(dlg.FileName, sql);
                        Logger.WriteLine("SQL saved to " + dlg.FileName);
                    }
                }
            }
        }

        private void DatabaseMigrator_MigrationTargetChanged(object sender, MigrationTargetChangedEventArgs e)
        {
            _currentConfiguration = e.MigrationConfiguration;

            lblMigrationTarget.Text = e.MigratorTitle;
            cmbMigrationTarget.Text = e.MigratorTitle;

            UpdateMigrationLists(e);
        }

        private void cmbConnectionString_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentConfiguration != null)
            {
                ConnectionStringSettings setting = ConnectionStrings.Single(x => x.Name == (string)cmbConnectionString.SelectedItem);

                Logger.WriteLine("Using connection string " + GetConnectionStringDisplay(setting));
                Logger.WriteLine();

                _currentConfiguration.TargetDatabase = new DbConnectionInfo(setting.Name);
                OnConnectionStringChanged(new ConnectionStringChangedEventArgs(_currentConfiguration, setting));
            }
        }

        private void DatabaseMigrator_ConnectionStringChanged(object sender, ConnectionStringChangedEventArgs e)
        {
            UpdateMigrationLists(e);
        }

        private void DatabaseMigrator_MigrationCompleted(object sender, DbMigratorEventArgs e)
        {
            UpdateMigrationLists(e);
        }

        private void lbPending_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPending = (string)lbPending.SelectedItem;
            SetMigrateSqlText();
            btnMigrate.Text = "Migrate to " + _currentPending;

            OnPendingMigrationTargetChanged(new MigrationChangedEventArgs(_currentConfiguration, _currentPending));
        }

        private void lbCompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCompleted = (string)lbCompleted.SelectedItem;
            btnRollbackSql.Text = "View Sql For Rollback To " + _currentCompleted;
            btnRollback.Text = "Rollback to " + _currentCompleted;
            btnMigrationHistory.Text = "View Migration History For " + _currentCompleted;

            OnCompletedMigrationChanged(new MigrationChangedEventArgs(_currentConfiguration, _currentPending));
        }

        private void btnMigrateSql_Click(object sender, EventArgs e)
        {
            HandleSql(GetMigrationSql(_currentConfiguration, _currentPending));
        }

        private void btnRollbackSql_Click(object sender, EventArgs e)
        {
            HandleSql(GetMigrationSql(_currentConfiguration, _currentCompleted));
        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to rollback to " + _currentCompleted + "?", "Rollback Migration", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                ExecuteMigration(_currentConfiguration, _currentCompleted);
            }
        }

        private void btnMigrate_Click(object sender, EventArgs e)
        {
            ExecuteMigration(_currentConfiguration, _currentPending);
        }

        private void btnMigrationHistory_Click(object sender, EventArgs e)
        {
            Logger.WriteLine();
            Logger.WriteLine(GetMigrationHistory(_currentConfiguration, _currentCompleted));
        }

        private void btnRollbackAllSql_Click(object sender, EventArgs e)
        {
            HandleSql(GetRollbackAllSql(_currentConfiguration));
        }

        private void btnRollbackAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to rollback all migrations?", "Rollback All Migrations", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                RollbackAll(_currentConfiguration);
            }
        }

        private void btnClearConsole_Click(object sender, EventArgs e)
        {
            txtConsole.Text = "";
        }

        private void btnReseed_Click(object sender, EventArgs e)
        {
            Logger.WriteLine();
            Logger.WriteLine("Reseeding...");
            Reseed(_currentConfiguration);
            Logger.WriteLine("Reseed complete.");
        }

        private void cmbMigrationTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (KeyValuePair<string, DbMigrationsConfiguration>)cmbMigrationTarget.SelectedItem;
            OnMigrationTargetChanged(new MigrationTargetChangedEventArgs(item.Value, item.Key));
        }

        private void btnIdempotent_Click(object sender, EventArgs e)
        {
            HandleSql(GetIdempotentMigrationSql(_currentConfiguration));
        }

        private void cmbSqlTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox sqlTarget = (ComboBox)sender;
            _currentSqlTarget = (string)sqlTarget.SelectedItem;
            OnSqlTargetChanged(new SqlTargetEventArgs(_currentSqlTarget));
        }

        private void DatabaseMigrator_SqlTargetChanged(object sender, SqlTargetEventArgs e)
        {
            SetMigrateSqlText();
            btnIdempotent.Text = "Get Idempotent Migration SQL To " + e.Target;
        }
    }
}
