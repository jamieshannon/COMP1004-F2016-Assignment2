/*
 * App Name: Sharp Auto Form
 * Author: Jamie Shannon
 * Student ID: 200328763
 * App Creation Date: October 14, 2016
 * Description: This app takes the cost of a vehicle from the user, the tradein allowance
 * and the desired features for the vehicle. The app then calculates the cost of the 
 * vehicle
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP1004_F2016_Assignment2
{
    public partial class SharpAutoForm : Form
    {
        //initialize variables that will be used to help with tracking for the radio options
        Boolean standard = true;
        Boolean pearlized = false;
        Boolean customizedDetailing = false;
        int finishChangeCounter = 0;

        public SharpAutoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method opens a message box telling the user about the application when the 
        /// about button on the menu strip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program calculates the amount due on a New or Used" +
                " Vehicle", "About");
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFontAndColour();
        }

        /// <summary>
        /// This method opens the font dialog window and allows the user to change the 
        /// font and font colour of the amount due text box and the base price text box
        /// </summary>
        private void ChangeFontAndColour()
        {
            FontDialog.ShowColor = true;

            FontDialog.Font = AmountDueTextBox.Font;
            FontDialog.Color = AmountDueTextBox.ForeColor;

            if (FontDialog.ShowDialog() != DialogResult.Cancel)
            {
                AmountDueTextBox.Font = FontDialog.Font;
                BasePriceTextBox.Font = FontDialog.Font;
                AmountDueTextBox.ForeColor = FontDialog.Color;
                BasePriceTextBox.ForeColor = FontDialog.Color;
            }
        }

        private void ColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFontAndColour();
        }

        /// <summary>
        /// This method calculates the additional costs that are incured when 
        /// the stereo system option is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StereoSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            double cost = Convert.ToDouble(AdditionalOptionsTextBox.Text);
            if (StereoSystemCheckBox.Checked == true)
            { 
                double newCost = cost + 425.76;
                AdditionalOptionsTextBox.Text = newCost.ToString();
            }
            else
            {
                double newCost = cost - 425.76;
                AdditionalOptionsTextBox.Text = newCost.ToString();
            }
        }

        /// <summary>
        /// This method calculates the additional costs incured if the leather interior
        /// option is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeatherInteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            double cost = Convert.ToDouble(AdditionalOptionsTextBox.Text);
            if (LeatherInteriorCheckBox.Checked == true)
            {
                double newCost = cost + 987.41;
                AdditionalOptionsTextBox.Text = newCost.ToString();
            }
            else
            {
                double newCost = cost - 987.41;
                AdditionalOptionsTextBox.Text = newCost.ToString();
            }
        }

        /// <summary>
        /// This method calculates the additional costs incured if the computer navigation
        /// system option is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComputerNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            double cost = Convert.ToDouble(AdditionalOptionsTextBox.Text);
            if (ComputerNavigationCheckBox.Checked == true)
            {
                double newCost = cost + 1741.23;
                AdditionalOptionsTextBox.Text = newCost.ToString();
            }
            else
            {
                double newCost = cost - 1741.23;
                AdditionalOptionsTextBox.Text = newCost.ToString();
            }
        }

        /// <summary>
        /// This method determines the additional costs incured if the pearlized option
        /// is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PearlizedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(PearlizedRadioButton.Checked == true)
            {
                double cost = Convert.ToDouble(AdditionalOptionsTextBox.Text);
                pearlized = true;
                finishChangeCounter++;
                //Check if this is the first time the radio button has been changed
                //if it is, add the pearlized cost to additional costs
                if (finishChangeCounter == 1)
                {
                    double newCost = cost + 345.72;
                    AdditionalOptionsTextBox.Text = newCost.ToString();
                    standard = false;
                    customizedDetailing = false;
                }
                else
                {
                    //if switching from standard just add the new ammount
                    if (standard == true)
                    {
                        double newCost = cost + 345.72;
                        AdditionalOptionsTextBox.Text = newCost.ToString();
                        standard = false;
                        customizedDetailing = false;
                    }
                    //if not switching from standard subtract the old cost and add the 
                    //new cost
                    else
                    {
                        double newCost = cost + 345.72 - 599.99;
                        AdditionalOptionsTextBox.Text = newCost.ToString();
                        standard = false;
                        customizedDetailing = false;
                    }
                }
            }
            
        }

        /// <summary>
        /// This method determines the additional costs when custom detailing is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomizedDetailingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomizedDetailingRadioButton.Checked == true)
            {
                double cost = Convert.ToDouble(AdditionalOptionsTextBox.Text);
                customizedDetailing = true;
                finishChangeCounter++;
                //if this is the first time the button has been changed just add the new
                //cost
                if (finishChangeCounter == 1)
                {
                    double newCost = cost + 599.99;
                    AdditionalOptionsTextBox.Text = newCost.ToString();
                    standard = false;
                    pearlized = false;
                }
                else
                {
                    //if switching from standard, just add the new cost
                    if (standard == true)
                    {
                        double newCost = cost + 599.99;
                        AdditionalOptionsTextBox.Text = newCost.ToString();
                        standard = false;
                        pearlized = false;
                    }
                    //if switching from pearlized, subtract the old cost and add the new cost
                    else
                    {
                        double newCost = cost + 599.99 - 345.72;
                        AdditionalOptionsTextBox.Text = newCost.ToString();
                        standard = false;
                        pearlized = false;
                    }
                }
            }
        }

        /// <summary>
        /// Determines the additional costs if standard is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StandardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (StandardRadioButton.Checked == true)
            {
                double cost = Convert.ToDouble(AdditionalOptionsTextBox.Text);
                standard = true;
                finishChangeCounter++;
                //if switching from pearlized subtract the appropriate amount
                if (pearlized == true)
                {
                    double newCost = cost - 345.72;
                    AdditionalOptionsTextBox.Text = newCost.ToString();
                    pearlized = false;
                    customizedDetailing = false;
                }
                //if switching from custom, subtract the appropriate amount
                else
                {
                    double newCost = cost - 599.99;
                    AdditionalOptionsTextBox.Text = newCost.ToString();
                    pearlized = false;
                    customizedDetailing = false;
                }
            }
        }
        /// <summary>
        /// Validates that the text input into the box is a number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BasePriceTextBox_Leave(object sender, EventArgs e)
        {
            if (BasePriceTextBox.Text != "")
            {
                double basePrice;
                try
                {
                    basePrice = Convert.ToDouble(BasePriceTextBox.Text);
                    BasePriceTextBox.Text = basePrice.ToString();
                }
                //Tell the user the data entered in invalid
                catch (Exception exception)
                {
                    MessageBox.Show("Invalid Data Entered", "Input Error");
                    Debug.WriteLine(exception.Message);
                    BasePriceTextBox.Focus();
                    BasePriceTextBox.Text = "";
                    BasePriceTextBox.SelectAll();
                }
            }
        }

        /// <summary>
        /// Validates that the trade in allowance input is a number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TradeInAllowanceTextBox_Leave(object sender, EventArgs e)
        {
            if (TradeInAllowanceTextBox.Text != "")
            {
                double tradeIn;
                try
                {
                    tradeIn = Convert.ToDouble(TradeInAllowanceTextBox.Text);
                    TradeInAllowanceTextBox.Text = tradeIn.ToString();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Invalid Data Entered", "Input Error");
                    Debug.WriteLine(exception.Message);
                    TradeInAllowanceTextBox.Focus();
                    TradeInAllowanceTextBox.Text = "";
                    TradeInAllowanceTextBox.SelectAll();
                }
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        /// <summary>
        /// Calculate the subtotal, sales tax, total, and amount due and show these numbers
        /// on the form
        /// </summary>
        private void Calculate()
        {
            double additionalCosts = Convert.ToDouble(AdditionalOptionsTextBox.Text);
            double basePrice = Convert.ToDouble(BasePriceTextBox.Text);

            double subTotal = Math.Round(additionalCosts + basePrice, 2);
            SubTotalTextBox.Text = subTotal.ToString();

            double salesTax = Math.Round(.13 * subTotal, 2);
            SalesTaxTextBox.Text = salesTax.ToString();

            double total = Math.Round(subTotal + salesTax, 2);
            TotalTextBox.Text = total.ToString();

            double tradeInAllowance = Convert.ToDouble(TradeInAllowanceTextBox.Text);
            double amountDue = Math.Round(total - tradeInAllowance, 2);
            AmountDueTextBox.Text = amountDue.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearForm();

        }

        /// <summary>
        /// Return all the text fields to their default values and reset the radio
        /// button tracking variables
        /// </summary>
        private void ClearForm()
        {
            BasePriceTextBox.Text = "";
            TradeInAllowanceTextBox.Text = "0";
            SubTotalTextBox.Text = "";
            SalesTaxTextBox.Text = "";
            TotalTextBox.Text = "";
            AmountDueTextBox.Text = "";

            StereoSystemCheckBox.Checked = false;
            LeatherInteriorCheckBox.Checked = false;
            ComputerNavigationCheckBox.Checked = false;

            StandardRadioButton.Checked = true;
            PearlizedRadioButton.Checked = false;
            CustomizedDetailingRadioButton.Checked = false;

            standard = true;
            pearlized = false;
            customizedDetailing = false;
            finishChangeCounter = 0;

            AdditionalOptionsTextBox.Text = "0";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            FormClose();
        }

        /// <summary>
        /// Close the form
        /// </summary>
        private void FormClose()
        {
            this.Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClose();
        }

        private void CalculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
