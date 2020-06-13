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
        private const string peopleFile = "PersonModel.csv";
        private const string teamFile = "TeamModel.csv";
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

        PersonModel IDataConnection.CreatePerson(PersonModel model)
        {
            // Load the text file
            // Convert file to List<PrizeModel>
            List<PersonModel> people = peopleFile.FullFilePath().LoadFile().ConvertToPersonModel();

            // Find the Highest value of id
            int currentId = 1;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.id).First().id + 1;
            }
            model.id = currentId;

            // Add the new record with the new ID(max + 1)
            people.Add(model);

            // Convert the prizes ot list<string>
            people.SaveToPersonFile(peopleFile);

            return model;
            // Save the list<string> to the text file
        }

        public List<PersonModel> GetPerson_All()
        {
            return peopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = teamFile.FullFilePath().LoadFile().ConvertToTeamModels(peopleFile);

            // Find the Highest value of id
            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.id).First().id + 1;
            }
            model.id = currentId;

            teams.Add(model);

            teams.SaveToTeamFile(teamFile);

            return model;
        }

        public List<TeamModel> GetTeams_All()
        {
            throw new NotImplementedException();
        }
    }
}
