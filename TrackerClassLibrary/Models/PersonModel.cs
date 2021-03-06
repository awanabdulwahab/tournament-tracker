﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents a person of a team
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// The unique identifer for the person
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents the First Name for a single Team Member 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Represents the Last  Name for a single Team Member 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Represents the email of a single Team Member 
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Represents the cell phone of a single Team Member 
        /// </summary>
        public string CellphoneNumber { get; set; }
        /// <summary>
        /// Represents the fulll name of person to show in dropdownlist
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{FirstName} { LastName }";
            }
        }
    }
}
