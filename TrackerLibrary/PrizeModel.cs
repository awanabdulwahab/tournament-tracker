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
        /// <summary>
        /// Empty consturctor to do nothing
        /// </summary>
        public PrizeModel()
        {

        }
        /// <summary>
        /// Overloaded contructor of PrizeModel Class
        /// </summary>
        public PrizeModel(string placename,string prizeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placename;

            int placeNumberValue = 0;
            int.TryParse(placename, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
