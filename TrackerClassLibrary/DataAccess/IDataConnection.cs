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
        /// <summary>
        /// This method takes a PersonModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// The Updated Person Model
        /// </returns>
        PersonModel CreatePerson(PersonModel model);
        TeamModel CreateTeam(TeamModel model);
        List<PersonModel> GetPerson_All();
        List<TeamModel> GetTeams_All();

    }
}
