namespace DVLD_System.Forms.MainMenuForms
{
    partial class frmCurrentUserDetails
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
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnSignout = new System.Windows.Forms.Button();
            this.ctrlDisplayUserData1 = new DVLD_System.Controls.ctrlDisplayUserData();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Image = global::DVLD_System.Properties.Resources.Change_Password_Icon;
            this.btnChangePassword.Location = new System.Drawing.Point(783, 439);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(198, 77);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Change Passoword";
            this.btnChangePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnSignout
            // 
            this.btnSignout.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignout.Image = global::DVLD_System.Properties.Resources.DeleteUserIcon1;
            this.btnSignout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignout.Location = new System.Drawing.Point(569, 439);
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.Size = new System.Drawing.Size(179, 77);
            this.btnSignout.TabIndex = 2;
            this.btnSignout.Text = "Sign out";
            this.btnSignout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignout.UseVisualStyleBackColor = true;
            this.btnSignout.Click += new System.EventHandler(this.btnSignout_Click);
            // 
            // ctrlDisplayUserData1
            // 
            this.ctrlDisplayUserData1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlDisplayUserData1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDisplayUserData1.Name = "ctrlDisplayUserData1";
            this.ctrlDisplayUserData1.Size = new System.Drawing.Size(1066, 400);
            this.ctrlDisplayUserData1.TabIndex = 0;
            // 
            // frmCurrentUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1071, 544);
            this.Controls.Add(this.btnSignout);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.ctrlDisplayUserData1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCurrentUserDetails";
            this.Text = "frmCurrentUserDetails";
            this.Load += new System.EventHandler(this.frmCurrentUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlDisplayUserData ctrlDisplayUserData1;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnSignout;
    }
}