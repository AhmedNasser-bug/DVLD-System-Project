namespace DVLD_System.Forms.ApplicationsManagementForms.LocalDrivingLicenseForms
{
    partial class frmScheuleTests
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmsAppointmentsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeAppointmentDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.ctrlDrivingLicenseApplicationDataData = new DVLD_System.Controls.ctrlDrivingLicenseApplicationDataData();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.cmsAppointmentsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(346, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Schedule Test";
            // 
            // cmsAppointmentsMenu
            // 
            this.cmsAppointmentsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeAppointmentDateToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsAppointmentsMenu.Name = "cmsAppointmentsMenu";
            this.cmsAppointmentsMenu.Size = new System.Drawing.Size(214, 48);
            // 
            // changeAppointmentDateToolStripMenuItem
            // 
            this.changeAppointmentDateToolStripMenuItem.Name = "changeAppointmentDateToolStripMenuItem";
            this.changeAppointmentDateToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.changeAppointmentDateToolStripMenuItem.Text = "Change appointment date";
            this.changeAppointmentDateToolStripMenuItem.Click += new System.EventHandler(this.changeAppointmentDateToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.takeTestToolStripMenuItem.Text = "Take test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmsAppointmentsMenu;
            this.dgvAppointments.Location = new System.Drawing.Point(12, 645);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.Size = new System.Drawing.Size(888, 146);
            this.dgvAppointments.TabIndex = 4;
            // 
            // ctrlDrivingLicenseApplicationDataData
            // 
            this.ctrlDrivingLicenseApplicationDataData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctrlDrivingLicenseApplicationDataData.Location = new System.Drawing.Point(6, 19);
            this.ctrlDrivingLicenseApplicationDataData.Name = "ctrlDrivingLicenseApplicationDataData";
            this.ctrlDrivingLicenseApplicationDataData.Size = new System.Drawing.Size(883, 413);
            this.ctrlDrivingLicenseApplicationDataData.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.ctrlDrivingLicenseApplicationDataData);
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(895, 438);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Previous appointments:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_System.Properties.Resources.ScheduleTests;
            this.pictureBox1.Location = new System.Drawing.Point(385, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAppointment.Image = global::DVLD_System.Properties.Resources.AddAppointment;
            this.btnAddAppointment.Location = new System.Drawing.Point(727, 574);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(173, 65);
            this.btnAddAppointment.TabIndex = 3;
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // frmScheuleTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(912, 803);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheuleTests";
            this.Text = "frmScheuleTests";
            this.cmsAppointmentsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Controls.ctrlDrivingLicenseApplicationDataData ctrlDrivingLicenseApplicationDataData;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.ContextMenuStrip cmsAppointmentsMenu;
        private System.Windows.Forms.ToolStripMenuItem changeAppointmentDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}