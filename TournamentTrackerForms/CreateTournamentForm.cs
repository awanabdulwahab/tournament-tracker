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
    public partial class CreateTournamentForm : Form,IPrizeRequestor,ITeamRequestor
    {
        List<TeamModel> availablTeams = GlobalConfig.Connection.GetTeams_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrize = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();
            Wireup();
        }

        private void Wireup()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availablTeams;
            selectTeamDropDown.DisplayMember= "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizeListBox.DataSource = null;
            prizeListBox.DataSource = selectedPrize;
            prizeListBox.DisplayMember = "PlaceName";
        }
        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel p = (TeamModel)selectTeamDropDown.SelectedItem;
            if(p != null)
            {
                availablTeams.Remove(p);
                selectedTeams.Add(p);

                Wireup();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call the create prize form
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();
            
        }

        public void PrizeComplete(PrizeModel model)
        {
            // Get back from the form PrizeModel
            // Take back the prizeModel and put back it in the selected list
            selectedPrize.Add(model);
            Wireup();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            Wireup();
        }

        private void createTeamLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }
    //    PersonModel p = (PersonModel)TeamMemberListBox.SelectedItem;
    //        if (p != null)
    //        {
    //            selectedTeamMembers.Remove(p);
    //            availableTeamMembers.Add(p);

    //            WireupList();
    //}

        private void deleteSelectedTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel p = (TeamModel)tournamentTeamsListBox.SelectedItem;
            if (p != null)
            {
                selectedTeams.Remove(p);
                availablTeams.Add(p);
                Wireup();
            }

        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizeListBox.SelectedItem;
            if (p != null)
            {
                selectedPrize.Remove(p);
                Wireup();
            }
        }

        private void createTournementButton_Click(object sender, EventArgs e)
        {
            //validate Data
            decimal fee = 0;
            bool feeAcceptable = decimal.TryParse(EntryFeeValue.Text, out fee);
            // Create Tournament Model
            TournamentModel tm = new TournamentModel();
            tm.TournamentName = TournamentNameValue.Text;
            if (!feeAcceptable)
            {
                MessageBox.Show("Your need to enter a vaild entry fee", 
                    "Invalid Entry Fee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            tm.EntryFee = fee;
            tm.Prizes = selectedPrize;
            tm.EnterTeam = selectedTeams;

            // Wireup  Matchups

            GlobalConfig.Connection.CreateTournament(tm);
            // Create Tournaments Entry
            // Create all of the prize entries
            // Create all of the Entires for teams
            

        }
    }
}
