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
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(15, 214);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1017, 302);
            this.txtLog.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
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
            // DatabaseMigrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 528);
            this.Controls.Add(this.cmbMigrationTarget);
            this.Controls.Add(this.lblMigrationTarget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
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
    }
}

