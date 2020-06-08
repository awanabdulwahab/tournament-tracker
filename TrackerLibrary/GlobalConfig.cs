using System;
using System.Collections.Generic;
using System.Text;

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

        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        /// <summary>
        /// At the begining of applicaiton, these are the connections I want to setup 
        /// </summary>
        /// <param name="database">
        /// Do you want database 
        /// </param>
        /// <param name="textFiles">
        /// Do you want the text file
        /// </param>
        public static void InitializeConnection(bool database, bool textFiles)
        {
            if (database)
            {
                // TODO - Set up the SQL Connector Properly
                SQLConnector sql = new SQLConnector();
                Connections.Add(sql); 
            }
            if (textFiles)
            {
                // TODO - Set up the Text Connector Properly
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
