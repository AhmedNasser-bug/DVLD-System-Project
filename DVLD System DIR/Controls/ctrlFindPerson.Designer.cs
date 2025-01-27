namespace DVLD_System.Controls
{
    partial class ctrlFindPerson
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
            this.ctrlDisplayPersonDetails1 = new DVLD_System.Controls.ctrlDisplayPersonDetails();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnFindPersonID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPersons = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ctrlDisplayPersonDetails1
            // 
            this.ctrlDisplayPersonDetails1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlDisplayPersonDetails1.Location = new System.Drawing.Point(7, 47);
            this.ctrlDisplayPersonDetails1.Name = "ctrlDisplayPersonDetails1";
            this.ctrlDisplayPersonDetails1.Size = new System.Drawing.Size(1045, 291);
            this.ctrlDisplayPersonDetails1.TabIndex = 0;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackgroundImage = global::DVLD_System.Properties.Resources.AddPerson_Icon;
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.Location = new System.Drawing.Point(356, 20);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(29, 23);
            this.btnAddPerson.TabIndex = 17;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnFindPersonID
            // 
            this.btnFindPersonID.BackgroundImage = global::DVLD_System.Properties.Resources.FindPersonICong;
            this.btnFindPersonID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindPersonID.Location = new System.Drawing.Point(321, 20);
            this.btnFindPersonID.Name = "btnFindPersonID";
            this.btnFindPersonID.Size = new System.Drawing.Size(29, 23);
            this.btnFindPersonID.TabIndex = 16;
            this.btnFindPersonID.UseVisualStyleBackColor = true;
            this.btnFindPersonID.Click += new System.EventHandler(this.btnFindPersonID_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select Person";
            // 
            // cbPersons
            // 
            this.cbPersons.FormattingEnabled = true;
            this.cbPersons.Location = new System.Drawing.Point(194, 20);
            this.cbPersons.Name = "cbPersons";
            this.cbPersons.Size = new System.Drawing.Size(121, 21);
            this.cbPersons.TabIndex = 14;
            // 
            // ctrlFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnFindPersonID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPersons);
            this.Controls.Add(this.ctrlDisplayPersonDetails1);
            this.Name = "ctrlFindPerson";
            this.Size = new System.Drawing.Size(1077, 359);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDisplayPersonDetails ctrlDisplayPersonDetails1;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnFindPersonID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPersons;
    }
}
