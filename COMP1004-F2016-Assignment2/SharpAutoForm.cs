using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP1004_F2016_Assignment2
{
    public partial class SharpAutoForm : Form
    {
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
    }
}
