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
        private List<PersonModel> availableTeamMembers= GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        public CreateTeamForm()
        {
            InitializeComponent();
            //CreateSampleData();
            WireupList();
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
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireupList();

            }
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

                p= GlobalConfig.Connection.CreatePerson(p);
                selectedTeamMembers.Add(p);
                WireupList();

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
            // TODO - Validate this form Correctly
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

        private void WireupList()
        {
            selectTeamMemberDropDown.DataSource = null;
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            TeamMemberListBox.DataSource = null;
            TeamMemberListBox.DataSource = selectedTeamMembers;
            TeamMemberListBox.DisplayMember = "FullName";

        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel {FirstName ="Tim",LastName= "Corey" });
            availableTeamMembers.Add(new PersonModel {FirstName ="Sam",LastName= "Storey" });

            selectedTeamMembers.Add(new PersonModel {FirstName ="Tim",LastName= "Corey" });
            selectedTeamMembers.Add(new PersonModel {FirstName ="Sam",LastName= "Storey" });

            
        }

        private void removeSelectedTeamMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)TeamMemberListBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireupList();
            }
        
        }

        private void createTeamtButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();

            t.TeamName = TeamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            t = GlobalConfig.Connection.CreateTeam(t);

            // TODO- Reset the form
        }
    }
}
