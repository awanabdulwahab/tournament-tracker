using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents what the prize is for the given place.
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifer for the prize
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents the place number team got when playing
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// Represents the place Name of team that team got in tournament
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// Represents the prize amount that team got
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// Represents the prize percentage of that team in the tournament
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
