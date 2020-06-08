using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    /// <summary>
    /// Interface to setup a contract with different classes to store data
    /// </summary>
    public interface IDataConnection
    {
        /// <summary>
        /// This method takes a prizemodel object
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// The updated prize model
        /// </returns>
        PrizeModel CreatePrize(PrizeModel model);
    }
}
