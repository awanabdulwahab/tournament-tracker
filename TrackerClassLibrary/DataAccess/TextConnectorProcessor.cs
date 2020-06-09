using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerClassLibrary.DataAccess.TextConnector
{
    public static class TextConnectorProcessor
    {
        public static string FullFillPath (string fileName) // PrizeModel.csv
        {
            // D:\UET\Summer\Windows Form Application\tournament tracker\Data\PrizeModel.csv
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{ fileName}";
        }
    }
}
