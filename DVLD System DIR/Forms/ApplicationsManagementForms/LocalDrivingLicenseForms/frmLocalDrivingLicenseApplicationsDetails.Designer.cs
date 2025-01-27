namespace DVLD_System.Forms.ApplicationsManagementForms.LocalDrivingLicenseForms
{
    partial class frmLocalDrivingLicenseApplicationsDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlDrivingLicenseApplicationDataData1 = new DVLD_System.Controls.ctrlDrivingLicenseApplicationDataData();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Local Driving License Applciation Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlDrivingLicenseApplicationDataData1);
            this.groupBox1.Location = new System.Drawing.Point(10, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 456);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application details";
            // 
            // ctrlDrivingLicenseApplicationDataData1
            // 
            this.ctrlDrivingLicenseApplicationDataData1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlDrivingLicenseApplicationDataData1.Location = new System.Drawing.Point(6, 19);
            this.ctrlDrivingLicenseApplicationDataData1.Name = "ctrlDrivingLicenseApplicationDataData1";
            this.ctrlDrivingLicenseApplicationDataData1.Size = new System.Drawing.Size(883, 431);
            this.ctrlDrivingLicenseApplicationDataData1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.LocalDrivingLicenseDetails;
            this.pictureBox1.Location = new System.Drawing.Point(119, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmLocalDrivingLicenseApplicationsDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(920, 537);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocalDrivingLicenseApplicationsDetails";
            this.Text = "frmLocalDrivingLicenseApplicationsDetails";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.ctrlDrivingLicenseApplicationDataData ctrlDrivingLicenseApplicationDataData1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}