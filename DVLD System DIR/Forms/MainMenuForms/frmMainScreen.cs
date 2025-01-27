using DVLD_System.Forms;
using DVLD_System.Forms.ApplicationsManagementForms;
using DVLD_System.Forms.ApplicationsManagementForms.LocalDrivingLicenseForms;
using DVLD_System.Forms.ApplicationsManagementForms.ManageApplicationTypesForms;
using DVLD_System.Forms.ApplicationsManagementForms.ManageTestTypesForms;
using DVLD_System.Forms.ApplicationsManagementForms.InternationalDrivingLicensesForms;
using DVLD_System.Forms.ManageDriversForms;
using DVLD_System.Forms.MainMenuForms;
using DVLD_System.Forms.ManageUsersForms;
using DVLD_System.Forms.ApplicationsManagementForms.LicenseManagementForms;
using DVLD_System;
using DVLDBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Media;
using DVLD_DataAccessLayer.Utils;
using System.IO;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace DVLD_System
{
    public partial class frmMainScreen : Form
    {
        // Initialize settings
        Form _formlogin;
        static string curDir = Directory.GetCurrentDirectory().Replace(@"bin\Debug", "");
        static string musicPath = curDir + @"Resources\Deltarune OST_ 15 - Lantern.wav";
        MediaPlayer BgMusicPlayer = new MediaPlayer();

        WinLogger mnfrmWinLogger = new WinLogger("DVLD Main Form");
        //---------------------------------------------------------------------------------------- Helper Methods

        public frmMainScreen(frmLoginScreen frmLogin)
        {
            InitializeComponent();

            // Initialize variables
            _formlogin = frmLogin;

            // Initialize controls
            BgMusicPlayer.Open(new Uri(musicPath));
            BgMusicPlayer.Volume = MusicTrackBar.Value / 100f;
            BgMusicPlayer.MediaEnded += TurnOnMusic;
            TurnOnMusic(this, null);
            
        }

        private void TurnOnMusic(object sender, EventArgs args )
        {
            try
            {
                BgMusicPlayer.Play();
            }
            catch (Exception ex)
            {
                mnfrmWinLogger.Error($"Error playing music: {ex.Message}");
            }
        }

        private void TurnOffMusic()
        {
            try
            {
                BgMusicPlayer.Pause();
            }
            catch (Exception ex)
            {
                mnfrmWinLogger.Error(ex);
            }
        }

        private void ShowGlobalUserSettings()
        {
            Form frmAccSettings = new frmCurrentUserDetails();

            frmAccSettings.ShowDialog();
        }

        // ---------------------------------------------------------------------------------------- Events
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManagePeople = new frmManagePeople();

            frmManagePeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();

            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManageAppTypes = new frmManageApplicationTypes();

            frmManageAppTypes.ShowDialog();
        }

        private void currentUserDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGlobalUserSettings();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form changePassForm = new frmChangePassword(User.GlobalUser);

            changePassForm.ShowDialog();
        }
        
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formlogin.Show();
            Close();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGlobalUserSettings();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmNewLocalDrivingLc = new frmAddNewLocalDrivingLicense();
            frmNewLocalDrivingLc.ShowDialog();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ManageTestTypes = new frmManageTestTypes();

            ManageTestTypes.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frmManageLocalDrivingLicenses = new frmManageLocalDrivingLicensesForm();
            frmManageLocalDrivingLicenses.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmManageDrivers = new frmManageDrivers();
            FrmManageDrivers.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManageInternationalDrivinglicenses = new frmManageInternationalLicense();
            frmManageInternationalDrivinglicenses.ShowDialog();
        }

        private void internationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmNewIternationalDrivingLicense = new frmAddInternationalDrivingLicense();
            frmNewIternationalDrivingLicense.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense frm = new frmRenewLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceForDamagedOrLost frm = new frmReplaceForDamagedOrLost();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, FormClosingEventArgs e)
        {
            _formlogin.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formlogin.Close();
            Close();
        }

        private void cbMusic_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbMusic.Checked) TurnOnMusic(this, null);
            else TurnOffMusic();
            
        }

        private void MusicTrackBar_ValueChanged(object sender, EventArgs e)
        {
            BgMusicPlayer.Volume = MusicTrackBar.Value / 100f;
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frmManageLocalDrivingLicenses = new frmManageLocalDrivingLicensesForm();
            frmManageLocalDrivingLicenses.ShowDialog();
        }
    }
}
