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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 251);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1025, 265);
            this.txtLog.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Migration target:";
            // 
            // lblMigrationTarget
            // 
            this.lblMigrationTarget.Location = new System.Drawing.Point(104, 16);
            this.lblMigrationTarget.Name = "lblMigrationTarget";
            this.lblMigrationTarget.Size = new System.Drawing.Size(300, 13);
            this.lblMigrationTarget.TabIndex = 2;
            // 
            // cmbMigrationTarget
            // 
            this.cmbMigrationTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMigrationTarget.FormattingEnabled = true;
            this.cmbMigrationTarget.Location = new System.Drawing.Point(101, 13);
            this.cmbMigrationTarget.Name = "cmbMigrationTarget";
            this.cmbMigrationTarget.Size = new System.Drawing.Size(300, 21);
            this.cmbMigrationTarget.TabIndex = 3;
            this.cmbMigrationTarget.Visible = false;
            // 
            // lbPending
            // 
            this.lbPending.FormattingEnabled = true;
            this.lbPending.Location = new System.Drawing.Point(12, 62);
            this.lbPending.Name = "lbPending";
            this.lbPending.Size = new System.Drawing.Size(400, 95);
            this.lbPending.TabIndex = 3;
            this.lbPending.SelectedIndexChanged += new System.EventHandler(this.lbPending_SelectedIndexChanged);
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.Location = new System.Drawing.Point(9, 46);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(100, 13);
            this.lblPending.TabIndex = 4;
            this.lblPending.Text = "Pending Migrations:";
            // 
            // lblCompleted
            // 
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Location = new System.Drawing.Point(425, 46);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(111, 13);
            this.lblCompleted.TabIndex = 9;
            this.lblCompleted.Text = "Completed Migrations:";
            // 
            // lbCompleted
            // 
            this.lbCompleted.FormattingEnabled = true;
            this.lbCompleted.Location = new System.Drawing.Point(428, 62);
            this.lbCompleted.Name = "lbCompleted";
            this.lbCompleted.Size = new System.Drawing.Size(400, 95);
            this.lbCompleted.TabIndex = 8;
            this.lbCompleted.SelectedIndexChanged += new System.EventHandler(this.lbCompleted_SelectedIndexChanged);
            // 
            // btnMigrateSql
            // 
            this.btnMigrateSql.Location = new System.Drawing.Point(12, 164);
            this.btnMigrateSql.Name = "btnMigrateSql";
            this.btnMigrateSql.Size = new System.Drawing.Size(400, 23);
            this.btnMigrateSql.TabIndex = 10;
            this.btnMigrateSql.Text = "View SQL For Migration";
            this.btnMigrateSql.UseVisualStyleBackColor = true;
            // 
            // btnMigrate
            // 
            this.btnMigrate.Location = new System.Drawing.Point(12, 194);
            this.btnMigrate.Name = "btnMigrate";
            this.btnMigrate.Size = new System.Drawing.Size(400, 23);
            this.btnMigrate.TabIndex = 11;
            this.btnMigrate.Text = "Migrate To";
            this.btnMigrate.UseVisualStyleBackColor = true;
            // 
            // btnRollbackSql
            // 
            this.btnRollbackSql.Location = new System.Drawing.Point(428, 163);
            this.btnRollbackSql.Name = "btnRollbackSql";
            this.btnRollbackSql.Size = new System.Drawing.Size(400, 23);
            this.btnRollbackSql.TabIndex = 12;
            this.btnRollbackSql.Text = "View SQL For Rollback";
            this.btnRollbackSql.UseVisualStyleBackColor = true;
            // 
            // btnRollback
            // 
            this.btnRollback.Location = new System.Drawing.Point(428, 193);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(400, 23);
            this.btnRollback.TabIndex = 13;
            this.btnRollback.Text = "Rollback To";
            this.btnRollback.UseVisualStyleBackColor = true;
            // 
            // btnMigrationHistory
            // 
            this.btnMigrationHistory.Location = new System.Drawing.Point(428, 222);
            this.btnMigrationHistory.Name = "btnMigrationHistory";
            this.btnMigrationHistory.Size = new System.Drawing.Size(400, 23);
            this.btnMigrationHistory.TabIndex = 14;
            this.btnMigrationHistory.Text = "View Migration History";
            this.btnMigrationHistory.UseVisualStyleBackColor = true;
            // 
            // DatabaseMigrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 528);
            this.Controls.Add(this.btnMigrationHistory);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.btnRollbackSql);
            this.Controls.Add(this.btnMigrate);
            this.Controls.Add(this.btnMigrateSql);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.cmbMigrationTarget);
            this.Controls.Add(this.lblMigrationTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lbPending);
            this.Controls.Add(this.lbCompleted);
            this.Controls.Add(this.lblCompleted);
            this.Name = "DatabaseMigrator";
            this.Text = "Database Migrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
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
    }
}

