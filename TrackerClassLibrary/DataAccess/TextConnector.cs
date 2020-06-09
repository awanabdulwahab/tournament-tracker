using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using TrackerClassLibrary.DataAccess.TextConnector;
using System.Linq;

namespace TrackerLibrary.DataAccess
{
    /// <summary>
    /// This class implements the IDataConneciton interface
    /// </summary>
    public class TextConnector : IDataConnection
    {
        private const string prizesFile = "PrizeModel.csv";
        // TODO - Make th CreatePrize method actually save to the textfile
        /// <summary>
        /// Saves the new prize to the text
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information, including unique indentifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the text file
            // Convert file to List<PrizeModel>
            List<PrizeModel> prizes = prizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();
           
            // Find the Highest value of id
            int currentId = 1;
            if (prizes.Count >0)
            {
                currentId = prizes.OrderByDescending(x => x.id).First().id + 1;
            }
            model.id = currentId;
            
            // Add the new record with the new ID(max + 1)
            prizes.Add(model);

            // Convert the prizes ot list<string>
            prizes.SaveToPrizeFile(prizesFile);

            return model;
            // Save the list<string> to the text file
        }
    }
}
