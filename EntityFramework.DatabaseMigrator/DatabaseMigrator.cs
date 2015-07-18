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
        public DatabaseMigrator()
            : base()
        {
            InitializeComponent();

            LoggerTextBox = txtLog;
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

                KeyValuePair<string, DbMigrator> keyValue = Migrators.First();

                lblMigrationTarget.Visible = true;
                lblMigrationTarget.Text = keyValue.Key;
            }
        }
    }
}
