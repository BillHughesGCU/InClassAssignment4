using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Elijah Olmos
//CST-117
//October 7, 2020
//In Class Assignment 4 IN Class Tag

namespace InClassAssignment4
{
    public partial class InClassAssignment4 : Form
    {
        public InClassAssignment4()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calculating days, hours, and minutes from a given amount of seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                //define variables
                int inputSeconds = Convert.ToInt32(txtElapsedSeconds.Text); //store user input
                var resultNumber = TimeSpan.FromSeconds(inputSeconds);   //prepare a variable to hold our result
                string resultText = "That is equivalent to ";   //define a template string

                //reset label color from last run
                lblOutput.ForeColor = System.Drawing.Color.CadetBlue;

                //convert seconds to seconds
                if ((inputSeconds < 60) & (inputSeconds > 0))
                {
                    /*
                     * general format: set the label text to the template string,
                     * plus the formatted numeric result, plus the units
                     */
                    lblOutput.Text = resultText + inputSeconds + " seconds";
                }
                //convert seconds to minutes
                else if ((inputSeconds >= 60) & (inputSeconds < 3600))
                {
                    // %m is a special format that removes leading zeros ( see Microsoft .NET Fundamentals > Custom TimeSpan Format Strings. )
                    lblOutput.Text = resultText + resultNumber.ToString("%m") + " whole minutes";
                }
                //convert seconds to hours
                else if ((inputSeconds >= 3600) & (inputSeconds <= 86400))
                {
                    lblOutput.Text = resultText + resultNumber.ToString("%h") + " whole hours";
                }
                //convert seconds to days
                else if (inputSeconds >= 86400)
                {
                    lblOutput.Text = resultText + resultNumber.ToString("%d") + " whole days";
                }
                else
                {
                    //catch-all error block for our if-else chain
                    lblOutput.ForeColor = System.Drawing.Color.Red;         //change label color
                    lblOutput.Text = "I am unable to convert that number";  //update label with specific error text
                }
            } 
            catch (FormatException ex)
            {
                lblOutput.ForeColor = System.Drawing.Color.Red; //change label color
                lblOutput.Text = "ERROR: That is not a number"; //update label with specific error text
            }
            catch (Exception ex)
            {
                lblOutput.ForeColor = System.Drawing.Color.Red; //change label color
                lblOutput.Text = "ERROR: Something went wrong"; //update label with generic error text
            }
        }
    }
}
