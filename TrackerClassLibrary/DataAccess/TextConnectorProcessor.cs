﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerClassLibrary.DataAccess.TextConnector
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// Return the full path of file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>
        /// Full path of file
        /// </returns>
        public static string FullFilePath (this string fileName) // PrizeModel.csv
        {
            // D:\UET\Summer\Windows Form Application\tournament tracker\Data\PrizeModel.csv
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{ fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }
        /// <summary>
        /// Checks each line of file and convert that line into list of PrizeModel
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static List<PrizeModel> ConvertToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach(string line in lines )
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);

                output.Add(p);
            }

            return output;
        }

        public static List<PersonModel> ConvertToPersonModel(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];

                output.Add(p);
            }

            return output;
        }

        public static List<TeamModel> ConvertToTeamModels(this List<string> lines,string peopleFileName)
        {
            //id, team name, list of ids: separated by the pipe
            //3,Team 1,1|3|5
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModel();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',') ;
                TeamModel t = new TeamModel();
                t.id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personids = cols[2].Split('|');

                foreach (string id in personids)
                {
                    t.TeamMembers.Add(people.Where(x => x.id == int.Parse(id)).First());
                }
                output.Add(t);
            }
            return output;

        }

        public static List<TournamentModel> ConvertToTournamentModel(this List<string> lines)
        {

        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToPersonFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{p.id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellphoneNumber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel p in models)
            {
                lines.Add($"{ p.id },{ p.TeamName },{ ConvertPeoplelistToString(p.TeamMembers) }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        private static string ConvertPeoplelistToString(List<PersonModel> people)
        {
            string output = "";
            //2|3
            if(people.Count == 0)
            {
                return output;
            }
            foreach (PersonModel p in people)
            {
                output += $"{p.id}|";
            }
            output = output.Substring(0, output.Length - 1);

            return output;
        }
    }
}
