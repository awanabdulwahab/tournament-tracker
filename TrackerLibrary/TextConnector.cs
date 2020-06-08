using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// This class implements the IDataConneciton interface
    /// </summary>
    public class TextConnector : IDataConnection
    {
        // TODO - Make th CreatePrize method actually save to the textfile
        /// <summary>
        /// Saves the new prize to the text
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information, including unique indentifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.id = 1;
            return model;
        }
    }
}
