namespace DVLD_System.Controls
{
    partial class ctrlDrivingLicenseApplicationDataData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblDriverAppID = new System.Windows.Forms.Label();
            this.lblPassedTests = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLicenseTitle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlShowApplicationInfo1 = new DVLD_System.Controls.ctrlShowApplicationInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "DriverApp ID: ";
            // 
            // lblDriverAppID
            // 
            this.lblDriverAppID.AutoSize = true;
            this.lblDriverAppID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverAppID.Location = new System.Drawing.Point(199, 16);
            this.lblDriverAppID.Name = "lblDriverAppID";
            this.lblDriverAppID.Size = new System.Drawing.Size(50, 25);
            this.lblDriverAppID.TabIndex = 1;
            this.lblDriverAppID.Text = "[???]";
            // 
            // lblPassedTests
            // 
            this.lblPassedTests.AutoSize = true;
            this.lblPassedTests.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassedTests.Location = new System.Drawing.Point(199, 69);
            this.lblPassedTests.Name = "lblPassedTests";
            this.lblPassedTests.Size = new System.Drawing.Size(50, 25);
            this.lblPassedTests.TabIndex = 3;
            this.lblPassedTests.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Passed Tests:";
            // 
            // lblLicenseTitle
            // 
            this.lblLicenseTitle.AutoSize = true;
            this.lblLicenseTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseTitle.Location = new System.Drawing.Point(555, 16);
            this.lblLicenseTitle.Name = "lblLicenseTitle";
            this.lblLicenseTitle.Size = new System.Drawing.Size(50, 25);
            this.lblLicenseTitle.TabIndex = 5;
            this.lblLicenseTitle.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(318, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Applied for License title: ";
            // 
            // ctrlShowApplicationInfo1
            // 
            this.ctrlShowApplicationInfo1.curApplication = null;
            this.ctrlShowApplicationInfo1.Location = new System.Drawing.Point(3, 114);
            this.ctrlShowApplicationInfo1.Name = "ctrlShowApplicationInfo1";
            this.ctrlShowApplicationInfo1.Size = new System.Drawing.Size(803, 297);
            this.ctrlShowApplicationInfo1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDriverAppID);
            this.groupBox1.Controls.Add(this.lblLicenseTitle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblPassedTests);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 105);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver details";
            // 
            // ctrlDrivingLicenseApplicationDataData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlShowApplicationInfo1);
            this.Name = "ctrlDrivingLicenseApplicationDataData";
            this.Size = new System.Drawing.Size(819, 414);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDriverAppID;
        private System.Windows.Forms.Label lblPassedTests;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLicenseTitle;
        private System.Windows.Forms.Label label6;
        private ctrlShowApplicationInfo ctrlShowApplicationInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
