namespace DVLD_System.Forms.ApplicationsManagementForms.InternationalDrivingLicensesForms
{
    partial class frmManageInternationalLicense
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
            this.ctrlFilterTable = new DVLD_System.Controls.ctrlFilterTable();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsInternationalLicenseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddIntLicesnse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsInternationalLicenseMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlFilterTable
            // 
            this.ctrlFilterTable.Location = new System.Drawing.Point(12, 66);
            this.ctrlFilterTable.Name = "ctrlFilterTable";
            this.ctrlFilterTable.Size = new System.Drawing.Size(963, 476);
            this.ctrlFilterTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(324, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "International Licenses";
            // 
            // cmsInternationalLicenseMenu
            // 
            this.cmsInternationalLicenseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseHistoryToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonDetailsToolStripMenuItem});
            this.cmsInternationalLicenseMenu.Name = "cmsInternationalLicenseMenu";
            this.cmsInternationalLicenseMenu.Size = new System.Drawing.Size(187, 70);
            this.cmsInternationalLicenseMenu.Text = "Show Person Details";
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // btnAddIntLicesnse
            // 
            this.btnAddIntLicesnse.BackgroundImage = global::DVLD_System.Properties.Resources.world;
            this.btnAddIntLicesnse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddIntLicesnse.Location = new System.Drawing.Point(921, 55);
            this.btnAddIntLicesnse.Name = "btnAddIntLicesnse";
            this.btnAddIntLicesnse.Size = new System.Drawing.Size(51, 47);
            this.btnAddIntLicesnse.TabIndex = 2;
            this.btnAddIntLicesnse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddIntLicesnse.UseVisualStyleBackColor = true;
            this.btnAddIntLicesnse.Click += new System.EventHandler(this.btnAddIntLicesnse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.world_europe_africa;
            this.pictureBox1.Location = new System.Drawing.Point(254, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(984, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddIntLicesnse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlFilterTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageInternationalLicense";
            this.Text = "frmManageInternationalLicense";
            this.cmsInternationalLicenseMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlFilterTable ctrlFilterTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenseMenu;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.Button btnAddIntLicesnse;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}