﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one team in a matchup
    /// </summary>
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents one team in the matchup
        /// </summary>
        public List<TeamModel> TeamsCompeting { get; set; } = new List<TeamModel>();
        /// <summary>
        /// Repreats the score for this particular team
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Repersents the matchup that this team come from as the winner
        /// </summary>
        public List<MatchupModel> ParentMatchup { get; set; }
    }
}
