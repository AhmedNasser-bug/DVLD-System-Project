using DVLD_System.Properties;
using DVLD_System.Utils;
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
    public partial class ctrlDisplayPersonDetails : UserControl
    {
        public Person person = new Person();
        
        public ctrlDisplayPersonDetails()
        {
            InitializeComponent();
        }

        public void ShowData(Person person)
        {
            this.person = person;
            lblAddress.Text = person.Address;
            lblCountry.Text = person.CountryName;
            lblDOB.Text = person.DateOfBirth.ToShortDateString();
            lblEmail.Text = person.Email;
            lblName.Text = person.FullName;
            lblNationalNo.Text = person.NationalNo;
            lblPhone.Text = person.Phone;
            if (person.Gender)
            {
                lblGender.Text = "female";
            }
            if(person.ImagePath != "")pbPersonPic.Image = Image.FromFile(person.ImagePath);
        }

        public string RemoveImage()
        {
            string oldImagePath = pbPersonPic.ImageLocation;
            pbPersonPic.Image = Resources.DefaultImage;
            return oldImagePath;
        }

        public void ResetImage(string imagePath)
        {
            pbPersonPic.ImageLocation = imagePath;
        }

        private void ctrlDisplayPersonDetails_Load(object sender, EventArgs e)
        {
            ShowData(person);
        }

        
    }
}
