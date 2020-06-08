using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournamentTrackerForms
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {

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
            bool placeNumberValidNumber = int.TryParse(placeNameValue.Text, out placenumber);
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
            int prizepercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeamount);
            bool prizepercentageValid = int.TryParse(prizePercentageValue.Text, out prizepercentage);
            if (prizeAmountValid == false || prizepercentageValid == false)
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
    }
}
