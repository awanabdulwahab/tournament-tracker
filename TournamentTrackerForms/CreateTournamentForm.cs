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
    public partial class CreateTournamentForm : Form
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
    }
}
