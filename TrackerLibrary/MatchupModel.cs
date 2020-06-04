using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class MatchupModel
    {
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        public List<TeamModel> Winner { get; set; } = new List<TeamModel>();
        public int MatchupRound { get; set; }
    }
}
