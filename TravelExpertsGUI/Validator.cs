using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsGUI
{
    /// <summary>
    /// a repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// tests if a textbox contains non-empty string
        /// </summary>
        /// <param name="textBox">text box to check</param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsPresent(TextBox textBox)
        {
            bool isValid = true; //"innocent until proven guilty"
            if(textBox.Text == "")
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} is required");
                textBox.Focus(); 
            }
            return isValid;
        }

        /// <summary>
        /// tests if a text box contains int that is >= 0
        /// </summary>
        /// <param name="textBox">text box to check</param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsNonNegativeInt(TextBox textBox)
        {
            bool isValid = true;
            int value; // parsed value if successful
            if(!Int32.TryParse(textBox.Text, out value)) // not an int
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be a whole number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < 0) // an int, but negative
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if the text box contains non-negative double value
        /// </summary>
        /// <param name="textBox">text box to check</param>
        /// <returns>true if valid and false if not</returns>       
        public static bool IsNonNegativeDouble(TextBox textBox)
        {
            bool isValid = true;
            double value; // parsed value if successful
            if (!Double.TryParse(textBox.Text, out value)) // not a double
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < 0) // a double, but negative
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }
        /// <summary>
        /// tests if the text box contains non-negative decimal value
        /// </summary>
        /// <param name="textBox">text box to check</param>
        /// <returns>true if valid and false if not</returns>       
        public static bool IsNonNegativeDecimal(TextBox textBox)
        {
            bool isValid = true;
            decimal value; // parsed value if successful
            if (!Decimal.TryParse(textBox.Text, out value)) // not a decimal
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < 0) // a decimal, but negative
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if the text box contains a decimal value within range
        /// </summary>
        /// <param name="textBox"> text box to check</param>
        /// <param name="minValue">minimum value for the range</param>
        /// <param name="maxValue">maximum value for the range</param>
        /// <returns></returns>
        public static bool IsDecimalInRange(TextBox textBox,
            decimal minValue, decimal maxValue)
        {
            bool isValid = true;
            decimal value; // parsed value if successful
            if (!Decimal.TryParse(textBox.Text, out value)) // not a decimal
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < minValue || value > maxValue) // a decimal, but out of range
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be between {minValue} and {maxValue}");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if the text box contains a double value within range
        /// </summary>
        /// <param name="textBox"> text box to check</param>
        /// <param name="minValue">minimum value for the range</param>
        /// <param name="maxValue">maximum value for the range</param>
        /// <returns></returns>
        public static bool IsDoubleInRange(TextBox textBox,
            double minValue, double maxValue)
        {
            bool isValid = true;
            double value; // parsed value if successful
            if (!Double.TryParse(textBox.Text, out value)) // not a double
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (value < minValue || value > maxValue) // a double, but out of range
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be between {minValue} and {maxValue}");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if combo box has an item selected
        /// </summary>
        /// <param name="combobox">combobox to check</param>
        /// <returns>true if selected. false if not selected</returns>
        public static bool IsSelected(ComboBox combobox)
        {
            bool isValid = true;
            if (combobox.SelectedIndex == -1)
            {
                isValid = false;
                MessageBox.Show($"{combobox.Tag} must be selected.");
                combobox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if the date is today or before 
        /// </summary>
        /// <param name="textBox">textbox to check</param>
        /// <returns>true if valid. false if not.</returns>
        public static bool IsDatePassed(TextBox textBox)
        {
            bool isValid = true;
            DateTime today = DateTime.Today;
            DateTime date = DateTime.Parse(textBox.Text);
            if (date > today)//date is in the future 
            {
                isValid = false;
                MessageBox.Show($"{textBox.Tag} must be today or a date in the past.");
                textBox.Focus();
            }

            return isValid;
        }

        /// <summary>
        /// tests if the given code already exists as a product code
        /// </summary>
        /// <param name="textBox">new product code</param>
        /// <returns>true is unique false if already exists</returns>
        //public static bool IsUnique(TextBox textBox)
        //{
        //    bool isValid = true;
        //    using(TechSupportContext db = new TechSupportContext())
        //    {
        //         isValid = !db.Products.Any(p => p.ProductCode == textBox.Text);
        //    }
        //    if (!isValid)
        //    {
        //        MessageBox.Show($"This Product Code already exists");
        //        return isValid;
        //    }
        //    return isValid;
        //}

    } // class
} // namespace
