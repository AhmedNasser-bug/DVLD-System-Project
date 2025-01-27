using DVLD_System.Properties;
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
    public partial class ctrlGetPersonData : UserControl
    {
        public Person curPerson = new Person();
        public ctrlGetPersonData()
        {
            InitializeComponent();

            cbCountry.DataSource = Country.CountriesTable().DefaultView;
            cbCountry.DisplayMember = "CountryName";

        }

        public bool Save()
        {
            bool saveResult = false;
            if (tbEmail.TextLength == 0 || tbPhone.TextLength == 0 || tbNationalNo.TextLength == 0 || tbFirstName.TextLength == 0 ||
                tbSecondName.TextLength == 0 || tbThirdName.TextLength == 0 || tbLastName.TextLength == 0 || (rbFemale.Checked == false && rbMale.Checked == false))
            {
                errorProvider1.SetError(this, "Some Fields Are Empty!");
                return saveResult;
            }

            ValidateNationalNo();
                
            curPerson.Phone = tbPhone.Text;
            curPerson.FirstName = tbFirstName.Text;
            curPerson.SecondName = tbSecondName.Text;
            curPerson.ThirdName = tbThirdName.Text;
            curPerson.LastName = tbLastName.Text;
            curPerson.DateOfBirth = dtpDateOfBirth.Value;
            curPerson.NationalityCountryID = cbCountry.SelectedIndex + 1;
            curPerson.Address = rtbAddress.Text;

            if (rbFemale.Checked)
            {
                curPerson.Gender = true;
            }

            saveResult = curPerson.Save();

            return saveResult;
                
            
        }

        public void LoadData(Person person)
        {
            tbEmail.Text = person.Email;
            tbFirstName.Text = person.FirstName;
            tbLastName.Text = person.LastName;
            tbNationalNo.Text = person.NationalNo;
            tbPhone.Text = person.Phone;
            tbSecondName.Text = person.SecondName;
            tbThirdName.Text = person.ThirdName; 
            rtbAddress.Text = person.Address;
            dtpDateOfBirth.Value = person.DateOfBirth;
            cbCountry.SelectedText = person.CountryName;
            rbFemale.Checked = person.Gender;
            rbMale.Checked = person.Gender;
            pbPersonImage.ImageLocation = person.ImagePath;
        }

        private void lnkImagePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                curPerson.ImagePath = file.FileName;
                pbPersonImage.ImageLocation = curPerson.ImagePath;
            }
            else
            {
                curPerson.ImagePath = "";
            }
        }

        private void ValidateNationalNo()
        {
            if (curPerson.PersonID != -1)
            {
                if (Person.IsPersonExist(tbNationalNo.Text) && Person.Find(tbNationalNo.Text).NationalNo != curPerson.NationalNo)
                {
                    errorProvider1.SetError(tbNationalNo, "Person Already Exists");
                    ActiveControl = tbNationalNo;
                }
                else
                {
                    curPerson.NationalNo = tbNationalNo.Text;
                    errorProvider1.Clear();
                }
            }
            else
            {
                if (Person.IsPersonExist(tbNationalNo.Text))
                {
                    errorProvider1.SetError(tbNationalNo, "Person Already Exists");
                    ActiveControl = tbNationalNo;
                }
                else
                {
                    curPerson.NationalNo = tbNationalNo.Text;
                    errorProvider1.Clear();
                }
            }
        }

        private void tbNationalNo_Leave(object sender, EventArgs e)
        {
            ValidateNationalNo();
        }

        private bool InvalidEmail(string Email)
        {
            return !tbEmail.Text.Contains('@') && tbEmail.Text.Length > 0;
        }

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if(InvalidEmail(tbEmail.Text))
            {
                errorProvider1.SetError(tbEmail, "Email in Wrong Format");
                ActiveControl = tbEmail;
            }
            else
            {
                curPerson.Email = tbEmail.Text;
            }
        }

        private void ctrlGetPersonData_Load(object sender, EventArgs e)
        {
            
        }

        public string RemoveImage()
        {
            string oldImage = pbPersonImage.ImageLocation;
            pbPersonImage.Image = Resources.DefaultImage;
            return oldImage;
        }

        public void ResetImage(string imagePath)
        {
            pbPersonImage.Image = Image.FromFile(imagePath);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemoveImage();
            curPerson.ImagePath = "";
        }
    }
}
