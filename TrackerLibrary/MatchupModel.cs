using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents the matchup class of tournament
    /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// Represents the matchup entry list of team in the tournament
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// Represents the winner between 2 teams
        /// </summary>
        public List<TeamModel> Winner { get; set; } = new List<TeamModel>();
        /// <summary>
        /// Represets the matchup round of the team in the tournament
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
