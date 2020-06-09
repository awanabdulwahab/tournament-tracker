using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TrackerClassLibrary;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    /// <summary>
    /// This class contains the dataconnetion to store data in text file or sql server
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// This list of data connection is used to save the data in both text file or sql server at the same time
        /// </summary>

        public static IDataConnection Connection { get; private set; }
        /// <summary>
        /// At the begining of applicaiton, these are the connections I want to setup 
        /// </summary>
        /// <param name="database">
        /// Do you want database 
        /// </param>
        /// <param name="textFiles">
        /// Do you want the text file
        /// </param>
        public static void InitializeConnection(DatabaseType db)
        {
            if (db == DatabaseType.Sql )
            {
                // TODO - Set up the SQL Connector Properly
                SQLConnector sql = new SQLConnector();
                Connection = sql; 
            }
            else if (db == DatabaseType.TextFile)
            {
                // TODO - Set up the Text Connector Properly
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }
        /// <summary>
        /// This function goes to App.config file 
        /// </summary>
        /// <param name="name">
        /// The name written in App.config name section
        /// </param>
        /// <returns>
        /// Return the connection string form App.config file
        /// </returns>
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
