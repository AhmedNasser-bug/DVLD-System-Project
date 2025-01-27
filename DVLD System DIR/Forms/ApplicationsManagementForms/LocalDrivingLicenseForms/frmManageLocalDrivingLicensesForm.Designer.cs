namespace DVLD_System.Forms.ApplicationsManagementForms.LocalDrivingLicenseForms
{
    partial class frmManageLocalDrivingLicensesForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSearchBy = new System.Windows.Forms.ComboBox();
            this.cmsDgvLDLChoices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eyeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writingTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLocalDrivingLicenses = new System.Windows.Forms.DataGridView();
            this.btnAddLDL = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsDgvLDLChoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(300, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Local driving licenses";
            // 
            // tbSearchBox
            // 
            this.tbSearchBox.Location = new System.Drawing.Point(221, 130);
            this.tbSearchBox.Name = "tbSearchBox";
            this.tbSearchBox.Size = new System.Drawing.Size(100, 20);
            this.tbSearchBox.TabIndex = 3;
            this.tbSearchBox.TextChanged += new System.EventHandler(this.tbSearchBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "filter by :";
            // 
            // cbSearchBy
            // 
            this.cbSearchBy.FormattingEnabled = true;
            this.cbSearchBy.Items.AddRange(new object[] {
            "Local Driving LicenseID",
            "Name",
            "National Number"});
            this.cbSearchBy.Location = new System.Drawing.Point(94, 129);
            this.cbSearchBy.Name = "cbSearchBy";
            this.cbSearchBy.Size = new System.Drawing.Size(121, 21);
            this.cbSearchBy.TabIndex = 5;
            // 
            // cmsDgvLDLChoices
            // 
            this.cmsDgvLDLChoices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.scheduleTestsToolStripMenuItem,
            this.issueLicenseToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showLicenseHistoryToolStripMenuItem});
            this.cmsDgvLDLChoices.Name = "cmsDgvLDLChoices";
            this.cmsDgvLDLChoices.Size = new System.Drawing.Size(205, 180);
            this.cmsDgvLDLChoices.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDgvLDLChoices_Opening);
            this.cmsDgvLDLChoices.Opened += new System.EventHandler(this.cmsDgvLDLChoices_Opened);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Enabled = false;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Enabled = false;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Enabled = false;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // scheduleTestsToolStripMenuItem
            // 
            this.scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eyeTestToolStripMenuItem,
            this.writingTestToolStripMenuItem,
            this.streetTestToolStripMenuItem});
            this.scheduleTestsToolStripMenuItem.Enabled = false;
            this.scheduleTestsToolStripMenuItem.Name = "scheduleTestsToolStripMenuItem";
            this.scheduleTestsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.scheduleTestsToolStripMenuItem.Text = "Schedule tests";
            // 
            // eyeTestToolStripMenuItem
            // 
            this.eyeTestToolStripMenuItem.Enabled = false;
            this.eyeTestToolStripMenuItem.Name = "eyeTestToolStripMenuItem";
            this.eyeTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.eyeTestToolStripMenuItem.Text = "Eye Test";
            this.eyeTestToolStripMenuItem.Click += new System.EventHandler(this.eyeTestToolStripMenuItem_Click);
            // 
            // writingTestToolStripMenuItem
            // 
            this.writingTestToolStripMenuItem.Enabled = false;
            this.writingTestToolStripMenuItem.Name = "writingTestToolStripMenuItem";
            this.writingTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.writingTestToolStripMenuItem.Text = "Writing Test";
            this.writingTestToolStripMenuItem.Click += new System.EventHandler(this.writingTestToolStripMenuItem_Click);
            // 
            // streetTestToolStripMenuItem
            // 
            this.streetTestToolStripMenuItem.Enabled = false;
            this.streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            this.streetTestToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.streetTestToolStripMenuItem.Text = "Street Test";
            this.streetTestToolStripMenuItem.Click += new System.EventHandler(this.streetTestToolStripMenuItem_Click);
            // 
            // issueLicenseToolStripMenuItem
            // 
            this.issueLicenseToolStripMenuItem.Enabled = false;
            this.issueLicenseToolStripMenuItem.Name = "issueLicenseToolStripMenuItem";
            this.issueLicenseToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.issueLicenseToolStripMenuItem.Text = "Issue license";
            this.issueLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueLicenseToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.showLicenseToolStripMenuItem.Text = "Show license";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Enabled = false;
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show license history";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // dgvLocalDrivingLicenses
            // 
            this.dgvLocalDrivingLicenses.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenses.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenses.ContextMenuStrip = this.cmsDgvLDLChoices;
            this.dgvLocalDrivingLicenses.Location = new System.Drawing.Point(12, 185);
            this.dgvLocalDrivingLicenses.Name = "dgvLocalDrivingLicenses";
            this.dgvLocalDrivingLicenses.ReadOnly = true;
            this.dgvLocalDrivingLicenses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvLocalDrivingLicenses.Size = new System.Drawing.Size(994, 340);
            this.dgvLocalDrivingLicenses.TabIndex = 7;
            // 
            // btnAddLDL
            // 
            this.btnAddLDL.Image = global::DVLD_System.Properties.Resources.AddLDL;
            this.btnAddLDL.Location = new System.Drawing.Point(930, 84);
            this.btnAddLDL.Name = "btnAddLDL";
            this.btnAddLDL.Size = new System.Drawing.Size(76, 92);
            this.btnAddLDL.TabIndex = 2;
            this.btnAddLDL.UseVisualStyleBackColor = true;
            this.btnAddLDL.Click += new System.EventHandler(this.btnAddLDL_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.LocalDrivingLicenseDetails;
            this.pictureBox1.Location = new System.Drawing.Point(222, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageLocalDrivingLicensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1018, 537);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvLocalDrivingLicenses);
            this.Controls.Add(this.cbSearchBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearchBox);
            this.Controls.Add(this.btnAddLDL);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageLocalDrivingLicensesForm";
            this.Text = "Manage local driving licenses";
            this.cmsDgvLDLChoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddLDL;
        private System.Windows.Forms.TextBox tbSearchBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSearchBy;
        private System.Windows.Forms.ContextMenuStrip cmsDgvLDLChoices;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenses;
        private System.Windows.Forms.ToolStripMenuItem eyeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writingTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}