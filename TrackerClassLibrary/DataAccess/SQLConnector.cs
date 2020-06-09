using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    /// <summary>
    /// This class implements the IDataConneciton interface
    /// </summary>
    public class SQLConnector : IDataConnection
    {
        // TODO - Make th CreatePrize method actually save to the database
        /// <summary>
        /// Saves the ne prize to the database
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information, including unique indentifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.id = 1;
            return model;
        }
        /// <summary>
        /// This function goes to App.config file 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// Return the connection string form App.config file
        /// </returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
