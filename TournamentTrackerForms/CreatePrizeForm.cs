﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TournamentTrackerForms
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequestor callingForm;
        public CreatePrizeForm(IPrizeRequestor caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                PrizeModel model = new PrizeModel(placeNumberValue.Text,
                    placeNameValue.Text, 
                    prizeAmountValue.Text, 
                    prizePercentageValue.Text);


                GlobalConfig.Connection.CreatePrize(model);
                callingForm.PrizeComplete(model);

                this.Close();
                //placeNameValue.Text = "";
                //placeNumberValue.Text = "";
                //prizeAmountValue.Text = "";
                //prizePercentageValue.Text = "";

            }
        }
        /// <summary>
        /// Validate the form create Prize 
        /// </summary>
        /// <returns>
        /// Returns true if all the information in form is valid
        /// </returns>
        private bool validateForm()
        {
            bool output = true;
            int placenumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placenumber);
            if (placeNumberValidNumber == false)
            {
                output = false;
            }
            if(placenumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeamount = 0;
            double prizepercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeamount);
            bool prizepercentageValid = double.TryParse(prizePercentageValue.Text, out prizepercentage);
            if (prizeAmountValid == false && prizepercentageValid == false)
            {
                output = false;
            }
            if (prizeamount <=0 && prizepercentage <= 0)
            {
                output = false;
            }
            if (prizepercentage<0 || prizepercentage > 100)
            {
                output = false;
            }
            return output;
        }

        private void CreatePrizeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
