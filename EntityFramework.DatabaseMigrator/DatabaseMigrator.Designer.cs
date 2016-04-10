namespace EntityFramework.DatabaseMigrator
{
    partial class DatabaseMigrator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblMigrationTarget = new System.Windows.Forms.Label();
            this.cmbMigrationTarget = new System.Windows.Forms.ComboBox();
            this.lbPending = new System.Windows.Forms.ListBox();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lbCompleted = new System.Windows.Forms.ListBox();
            this.btnMigrateSql = new System.Windows.Forms.Button();
            this.btnMigrate = new System.Windows.Forms.Button();
            this.btnRollbackSql = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            this.btnMigrationHistory = new System.Windows.Forms.Button();
            this.btnRollbackAll = new System.Windows.Forms.Button();
            this.btnRollbackAllSql = new System.Windows.Forms.Button();
            this.btnClearConsole = new System.Windows.Forms.Button();
            this.btnReseed = new System.Windows.Forms.Button();
            this.btnIdempotent = new System.Windows.Forms.Button();
            this.lblSqlTarget = new System.Windows.Forms.Label();
            this.cmbSqlTarget = new System.Windows.Forms.ComboBox();
            this.lblConsole = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.cmbConnectionString = new System.Windows.Forms.ComboBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(16, 382);
            this.txtConsole.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(1296, 278);
            this.txtConsole.TabIndex = 0;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(16, 20);
            this.lblTarget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(111, 17);
            this.lblTarget.TabIndex = 1;
            this.lblTarget.Text = "Migration target:";
            // 
            // lblMigrationTarget
            // 
            this.lblMigrationTarget.Location = new System.Drawing.Point(148, 20);
            this.lblMigrationTarget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMigrationTarget.Name = "lblMigrationTarget";
            this.lblMigrationTarget.Size = new System.Drawing.Size(402, 16);
            this.lblMigrationTarget.TabIndex = 2;
            // 
            // cmbMigrationTarget
            // 
            this.cmbMigrationTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMigrationTarget.FormattingEnabled = true;
            this.cmbMigrationTarget.Location = new System.Drawing.Point(148, 16);
            this.cmbMigrationTarget.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMigrationTarget.Name = "cmbMigrationTarget";
            this.cmbMigrationTarget.Size = new System.Drawing.Size(400, 24);
            this.cmbMigrationTarget.TabIndex = 3;
            this.cmbMigrationTarget.Visible = false;
            // 
            // lbPending
            // 
            this.lbPending.FormattingEnabled = true;
            this.lbPending.ItemHeight = 16;
            this.lbPending.Location = new System.Drawing.Point(16, 109);
            this.lbPending.Margin = new System.Windows.Forms.Padding(4);
            this.lbPending.Name = "lbPending";
            this.lbPending.Size = new System.Drawing.Size(532, 116);
            this.lbPending.TabIndex = 3;
            this.lbPending.SelectedIndexChanged += new System.EventHandler(this.lbPending_SelectedIndexChanged);
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.Location = new System.Drawing.Point(16, 90);
            this.lblPending.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(133, 17);
            this.lblPending.TabIndex = 4;
            this.lblPending.Text = "Pending Migrations:";
            // 
            // lblCompleted
            // 
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Location = new System.Drawing.Point(571, 90);
            this.lblCompleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(148, 17);
            this.lblCompleted.TabIndex = 9;
            this.lblCompleted.Text = "Completed Migrations:";
            // 
            // lbCompleted
            // 
            this.lbCompleted.FormattingEnabled = true;
            this.lbCompleted.ItemHeight = 16;
            this.lbCompleted.Location = new System.Drawing.Point(571, 109);
            this.lbCompleted.Margin = new System.Windows.Forms.Padding(4);
            this.lbCompleted.Name = "lbCompleted";
            this.lbCompleted.Size = new System.Drawing.Size(532, 116);
            this.lbCompleted.TabIndex = 8;
            this.lbCompleted.SelectedIndexChanged += new System.EventHandler(this.lbCompleted_SelectedIndexChanged);
            // 
            // btnMigrateSql
            // 
            this.btnMigrateSql.Location = new System.Drawing.Point(16, 235);
            this.btnMigrateSql.Margin = new System.Windows.Forms.Padding(4);
            this.btnMigrateSql.Name = "btnMigrateSql";
            this.btnMigrateSql.Size = new System.Drawing.Size(533, 28);
            this.btnMigrateSql.TabIndex = 10;
            this.btnMigrateSql.Text = "Get SQL For Migration";
            this.btnMigrateSql.UseVisualStyleBackColor = true;
            this.btnMigrateSql.Click += new System.EventHandler(this.btnMigrateSql_Click);
            // 
            // btnMigrate
            // 
            this.btnMigrate.Location = new System.Drawing.Point(16, 272);
            this.btnMigrate.Margin = new System.Windows.Forms.Padding(4);
            this.btnMigrate.Name = "btnMigrate";
            this.btnMigrate.Size = new System.Drawing.Size(533, 28);
            this.btnMigrate.TabIndex = 11;
            this.btnMigrate.Text = "Migrate To";
            this.btnMigrate.UseVisualStyleBackColor = true;
            this.btnMigrate.Click += new System.EventHandler(this.btnMigrate_Click);
            // 
            // btnRollbackSql
            // 
            this.btnRollbackSql.Location = new System.Drawing.Point(571, 234);
            this.btnRollbackSql.Margin = new System.Windows.Forms.Padding(4);
            this.btnRollbackSql.Name = "btnRollbackSql";
            this.btnRollbackSql.Size = new System.Drawing.Size(533, 28);
            this.btnRollbackSql.TabIndex = 12;
            this.btnRollbackSql.Text = "View SQL For Rollback";
            this.btnRollbackSql.UseVisualStyleBackColor = true;
            this.btnRollbackSql.Click += new System.EventHandler(this.btnRollbackSql_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Location = new System.Drawing.Point(571, 271);
            this.btnRollback.Margin = new System.Windows.Forms.Padding(4);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(533, 28);
            this.btnRollback.TabIndex = 13;
            this.btnRollback.Text = "Rollback To";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // btnMigrationHistory
            // 
            this.btnMigrationHistory.Location = new System.Drawing.Point(571, 306);
            this.btnMigrationHistory.Margin = new System.Windows.Forms.Padding(4);
            this.btnMigrationHistory.Name = "btnMigrationHistory";
            this.btnMigrationHistory.Size = new System.Drawing.Size(533, 28);
            this.btnMigrationHistory.TabIndex = 14;
            this.btnMigrationHistory.Text = "View Migration History";
            this.btnMigrationHistory.UseVisualStyleBackColor = true;
            this.btnMigrationHistory.Click += new System.EventHandler(this.btnMigrationHistory_Click);
            // 
            // btnRollbackAll
            // 
            this.btnRollbackAll.BackColor = System.Drawing.Color.Red;
            this.btnRollbackAll.ForeColor = System.Drawing.Color.White;
            this.btnRollbackAll.Location = new System.Drawing.Point(1113, 109);
            this.btnRollbackAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnRollbackAll.Name = "btnRollbackAll";
            this.btnRollbackAll.Size = new System.Drawing.Size(200, 28);
            this.btnRollbackAll.TabIndex = 15;
            this.btnRollbackAll.Text = "Rollback All Migrations";
            this.btnRollbackAll.UseVisualStyleBackColor = false;
            this.btnRollbackAll.Click += new System.EventHandler(this.btnRollbackAll_Click);
            // 
            // btnRollbackAllSql
            // 
            this.btnRollbackAllSql.Location = new System.Drawing.Point(1113, 146);
            this.btnRollbackAllSql.Margin = new System.Windows.Forms.Padding(4);
            this.btnRollbackAllSql.Name = "btnRollbackAllSql";
            this.btnRollbackAllSql.Size = new System.Drawing.Size(200, 28);
            this.btnRollbackAllSql.TabIndex = 16;
            this.btnRollbackAllSql.Text = "View SQL For Rollback All";
            this.btnRollbackAllSql.UseVisualStyleBackColor = true;
            this.btnRollbackAllSql.Click += new System.EventHandler(this.btnRollbackAllSql_Click);
            // 
            // btnClearConsole
            // 
            this.btnClearConsole.Location = new System.Drawing.Point(82, 346);
            this.btnClearConsole.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearConsole.Name = "btnClearConsole";
            this.btnClearConsole.Size = new System.Drawing.Size(100, 28);
            this.btnClearConsole.TabIndex = 17;
            this.btnClearConsole.Text = "Clear";
            this.btnClearConsole.UseVisualStyleBackColor = true;
            this.btnClearConsole.Click += new System.EventHandler(this.btnClearConsole_Click);
            // 
            // btnReseed
            // 
            this.btnReseed.Location = new System.Drawing.Point(1113, 197);
            this.btnReseed.Margin = new System.Windows.Forms.Padding(4);
            this.btnReseed.Name = "btnReseed";
            this.btnReseed.Size = new System.Drawing.Size(199, 28);
            this.btnReseed.TabIndex = 18;
            this.btnReseed.Text = "Reseed";
            this.btnReseed.UseVisualStyleBackColor = true;
            this.btnReseed.Click += new System.EventHandler(this.btnReseed_Click);
            // 
            // btnIdempotent
            // 
            this.btnIdempotent.Location = new System.Drawing.Point(16, 306);
            this.btnIdempotent.Name = "btnIdempotent";
            this.btnIdempotent.Size = new System.Drawing.Size(532, 28);
            this.btnIdempotent.TabIndex = 19;
            this.btnIdempotent.Text = "Get Idempotent Migration SQL";
            this.btnIdempotent.UseVisualStyleBackColor = true;
            this.btnIdempotent.Click += new System.EventHandler(this.btnIdempotent_Click);
            // 
            // lblSqlTarget
            // 
            this.lblSqlTarget.AutoSize = true;
            this.lblSqlTarget.Location = new System.Drawing.Point(571, 20);
            this.lblSqlTarget.Name = "lblSqlTarget";
            this.lblSqlTarget.Size = new System.Drawing.Size(86, 17);
            this.lblSqlTarget.TabIndex = 20;
            this.lblSqlTarget.Text = "SQL Target:";
            // 
            // cmbSqlTarget
            // 
            this.cmbSqlTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSqlTarget.FormattingEnabled = true;
            this.cmbSqlTarget.Location = new System.Drawing.Point(663, 16);
            this.cmbSqlTarget.Name = "cmbSqlTarget";
            this.cmbSqlTarget.Size = new System.Drawing.Size(93, 24);
            this.cmbSqlTarget.TabIndex = 21;
            this.cmbSqlTarget.SelectedIndexChanged += new System.EventHandler(this.cmbSqlTarget_SelectedIndexChanged);
            // 
            // lblConsole
            // 
            this.lblConsole.AutoSize = true;
            this.lblConsole.Location = new System.Drawing.Point(12, 352);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Size = new System.Drawing.Size(63, 17);
            this.lblConsole.TabIndex = 22;
            this.lblConsole.Text = "Console:";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(16, 52);
            this.lblConnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(124, 17);
            this.lblConnection.TabIndex = 23;
            this.lblConnection.Text = "Connection String:";
            // 
            // cmbConnectionString
            // 
            this.cmbConnectionString.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnectionString.FormattingEnabled = true;
            this.cmbConnectionString.Location = new System.Drawing.Point(148, 48);
            this.cmbConnectionString.Margin = new System.Windows.Forms.Padding(4);
            this.cmbConnectionString.Name = "cmbConnectionString";
            this.cmbConnectionString.Size = new System.Drawing.Size(400, 24);
            this.cmbConnectionString.TabIndex = 24;
            this.cmbConnectionString.Visible = false;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.Location = new System.Drawing.Point(148, 52);
            this.lblConnectionString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(955, 16);
            this.lblConnectionString.TabIndex = 25;
            // 
            // DatabaseMigrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 676);
            this.Controls.Add(this.cmbConnectionString);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.lblConsole);
            this.Controls.Add(this.cmbSqlTarget);
            this.Controls.Add(this.lblSqlTarget);
            this.Controls.Add(this.btnIdempotent);
            this.Controls.Add(this.btnReseed);
            this.Controls.Add(this.btnClearConsole);
            this.Controls.Add(this.btnRollbackAllSql);
            this.Controls.Add(this.btnRollbackAll);
            this.Controls.Add(this.btnMigrationHistory);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.btnRollbackSql);
            this.Controls.Add(this.btnMigrate);
            this.Controls.Add(this.btnMigrateSql);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.cmbMigrationTarget);
            this.Controls.Add(this.lblMigrationTarget);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.lbPending);
            this.Controls.Add(this.lbCompleted);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblConnectionString);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DatabaseMigrator";
            this.Text = "Database Migrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblMigrationTarget;
        private System.Windows.Forms.ComboBox cmbMigrationTarget;
        private System.Windows.Forms.ListBox lbPending;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.ListBox lbCompleted;
        private System.Windows.Forms.Button btnMigrateSql;
        private System.Windows.Forms.Button btnMigrate;
        private System.Windows.Forms.Button btnRollbackSql;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Button btnMigrationHistory;
        private System.Windows.Forms.Button btnRollbackAll;
        private System.Windows.Forms.Button btnRollbackAllSql;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.Button btnReseed;
        private System.Windows.Forms.Button btnIdempotent;
        private System.Windows.Forms.Label lblSqlTarget;
        private System.Windows.Forms.ComboBox cmbSqlTarget;
        private System.Windows.Forms.Label lblConsole;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.ComboBox cmbConnectionString;
        private System.Windows.Forms.Label lblConnectionString;
    }
}

