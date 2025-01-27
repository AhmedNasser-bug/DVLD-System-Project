namespace DVLD_System.Controls
{
    partial class ctrlFindLicense
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
            this.btnFindLicenseID = new System.Windows.Forms.Button();
            this.cbLicenseIDs = new System.Windows.Forms.ComboBox();
            this.ctrlShowLicense = new DVLD_System.Controls.ctrlShowLicense();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find License:";
            // 
            // btnFindLicenseID
            // 
            this.btnFindLicenseID.BackgroundImage = global::DVLD_System.Properties.Resources.check_mark;
            this.btnFindLicenseID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindLicenseID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLicenseID.Location = new System.Drawing.Point(263, 22);
            this.btnFindLicenseID.Name = "btnFindLicenseID";
            this.btnFindLicenseID.Size = new System.Drawing.Size(29, 23);
            this.btnFindLicenseID.TabIndex = 17;
            this.btnFindLicenseID.UseVisualStyleBackColor = true;
            this.btnFindLicenseID.Click += new System.EventHandler(this.btnFindLicenseID_Click);
            // 
            // cbLicenseIDs
            // 
            this.cbLicenseIDs.FormattingEnabled = true;
            this.cbLicenseIDs.Location = new System.Drawing.Point(135, 24);
            this.cbLicenseIDs.Name = "cbLicenseIDs";
            this.cbLicenseIDs.Size = new System.Drawing.Size(121, 21);
            this.cbLicenseIDs.TabIndex = 19;
            this.cbLicenseIDs.SelectedIndexChanged += new System.EventHandler(this.cbLicenseIDs_SelectedIndexChanged);
            // 
            // ctrlShowLicense
            // 
            this.ctrlShowLicense.Location = new System.Drawing.Point(9, 69);
            this.ctrlShowLicense.Name = "ctrlShowLicense";
            this.ctrlShowLicense.Size = new System.Drawing.Size(1015, 257);
            this.ctrlShowLicense.TabIndex = 18;
            // 
            // ctrlFindLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.cbLicenseIDs);
            this.Controls.Add(this.ctrlShowLicense);
            this.Controls.Add(this.btnFindLicenseID);
            this.Controls.Add(this.label1);
            this.Name = "ctrlFindLicense";
            this.Size = new System.Drawing.Size(1029, 327);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindLicenseID;
        private ctrlShowLicense ctrlShowLicense;
        public System.Windows.Forms.ComboBox cbLicenseIDs;
    }
}
