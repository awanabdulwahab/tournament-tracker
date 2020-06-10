using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TournamentTrackerForms
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CreateTeamForm_Load(object sender, EventArgs e)
        {

        }

        private void selectTeamMemberLabel_Click(object sender, EventArgs e)
        {

        }

        private void selectTeamMemberDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                PersonModel p = new PersonModel();
                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = memberEmailValue.Text;
                p.CellphoneNumber = cellPhoneValue.Text;

                GlobalConfig.Connection.CreatePerson(p);
                firstNameValue.Text = "";
                lastNameValue.Text = "";
                memberEmailValue.Text = "";
                cellPhoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("Please Enter all fields ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private bool validateForm()
        {
            if (firstNameValue.Text.Length ==0)
            {
                return false;
            } 
            if (lastNameValue.Text.Length ==0)
            {
                return false;
            } 
            if (memberEmailValue.Text.Length ==0)
            {
                return false;
            }
            if (cellPhoneValue.Text.Length ==0)
            {
                return false;
            }
            return true;
            
        }
    }
}
