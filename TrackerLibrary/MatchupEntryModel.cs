using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
        public List<TeamModel> TeamsCompeting { get; set; } = new List<TeamModel>();
        public double Score { get; set; }
        public List<MatchupModel> ParentMatchup { get; set; }
    }
}
