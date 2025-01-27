namespace DVLD_System.Forms.ManageDriversForms
{
    partial class frmManageDrivers
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
            this.cmsDriversChoices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDriverDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlFilterTable = new DVLD_System.Controls.ctrlFilterTable();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsDriversChoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsDriversChoices
            // 
            this.cmsDriversChoices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDriverDetailsToolStripMenuItem});
            this.cmsDriversChoices.Name = "cmsDriversChoices";
            this.cmsDriversChoices.Size = new System.Drawing.Size(176, 26);
            // 
            // showDriverDetailsToolStripMenuItem
            // 
            this.showDriverDetailsToolStripMenuItem.Name = "showDriverDetailsToolStripMenuItem";
            this.showDriverDetailsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.showDriverDetailsToolStripMenuItem.Text = "Show Driver Details";
            this.showDriverDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDriverDetailsToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(404, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Drivers";
            // 
            // ctrlFilterTable
            // 
            this.ctrlFilterTable.Location = new System.Drawing.Point(12, 87);
            this.ctrlFilterTable.Name = "ctrlFilterTable";
            this.ctrlFilterTable.Size = new System.Drawing.Size(963, 476);
            this.ctrlFilterTable.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.Drivers_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(326, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(985, 576);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlFilterTable);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageDrivers";
            this.Text = "frmManageDrivers";
            this.cmsDriversChoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsDriversChoices;
        private System.Windows.Forms.ToolStripMenuItem showDriverDetailsToolStripMenuItem;
        private Controls.ctrlFilterTable ctrlFilterTable;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}