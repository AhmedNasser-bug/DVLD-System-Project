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

namespace DVLD_System.Controls
{
    public partial class ctrlShowApplicationInfo : UserControl
    {
        public Application_ curApplication {  get; set; }

        public ctrlShowApplicationInfo()
        {
            InitializeComponent();            
        }

        public void InitializeLabels(Application_ Application)
        {
            curApplication = Application;
            lblAppID.Text = curApplication.ApplicationID.ToString();
            lblApplcationFees.Text = curApplication.PaidFees.ToString();
            lblApplicantName.Text = curApplication.AssociatedPerson.FullName.ToString();
            lblApplicationDate.Text = curApplication.ApplicationDate.ToString();
            lblApplicationStatus.Text = curApplication.ApplicationStatus.ToString();
            lblStatusDate.Text = curApplication.LastStatusDate.ToString();
            lblCreatedByUser.Text = curApplication.CreatedByUser.AssociatedPerson.FullName.ToString();
            lblAppTypeName.Text = curApplication.AssociatedAppType.AppTypeTitle;
        }

        
    }
}
