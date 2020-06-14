using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Net.Http.Headers;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    /// <summary>
    /// This class implements the IDataConneciton interface
    /// </summary>
    public class SQLConnector : IDataConnection
    {
        private const string db = "Tournaments";
        // TODO - Make th CreatePrize method actually save to the database
        /// <summary>
        /// Saves the ne prize to the database
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information, including unique indentifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32,direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_insert",p , commandType:CommandType.StoredProcedure);

                model.id = p.Get<int>("@id");

                return model;
            }
        }

        PersonModel IDataConnection.CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumber", model.CellphoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_insert", p, commandType: CommandType.StoredProcedure);

                model.id = p.Get<int>("@id");

                return model;
            }
        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();                
            }
            return output;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@TeamName", model.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                model.id = p.Get<int>("@id");

                foreach (PersonModel tm in model.TeamMembers)
                {

                    p = new DynamicParameters();
                    p.Add("@Teamid", model.id);
                    p.Add("@PersonID", tm.id);
                    connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
                }

                return model;
            } 
        }

        public List<TeamModel> GetTeams_All()
        {
            List<TeamModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                foreach (TeamModel team in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@Teamid", team.id);
                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam",p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            return output;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                SaveTournament(model,connection);

                SaveTournamentPrizes(model, connection);

                SaveTournamentEntries(model, connection);

                
                return model;
            }
        }
        private static void SaveTournament(TournamentModel model, IDbConnection connection)
        {
            var p = new DynamicParameters();
            p.Add("@TournamentName", model.TournamentName);
            p.Add("@EntryFee", model.EntryFee);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spTournaments_insert", p, commandType: CommandType.StoredProcedure);

            model.id = p.Get<int>("@id");
        }
        private static void SaveTournamentPrizes(TournamentModel model, IDbConnection connection)
        {
            foreach (PrizeModel pz in model.Prizes)
            {
                p = new DynamicParameters();
                p.Add("@Tournamentid", model.id);
                p.Add("@Prizeid", pz.id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spTournamentPrizes_insert", p, commandType: CommandType.StoredProcedure);
            }
        }
        private static void SaveTournamentEntries(TournamentModel model, IDbConnection connection)
        {    
            foreach (TeamModel tm in model.EnterTeam)
            {
                var p = new DynamicParameters();
                p = new DynamicParameters();
                p.Add("@Tournamentid", model.id);
                p.Add("@Prizeid", tm.id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spTournamentEntries_insert", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
