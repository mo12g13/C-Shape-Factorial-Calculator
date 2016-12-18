using System;

using System.Windows.Forms;
/*
 * Author: Momo Johnson
 * C# Sharp Project 5.1 
 * This program calculates the factorial of a number from 1-20
 * 
 * */
namespace FactorialExceptionHandlingAndChecking
{
    public partial class Factorial : Form
    {
        public Factorial()
        {
            InitializeComponent();
        }

        //An event handler that calculates the factorial once it is clicked
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            long factorialCalculatedValuse = 1;//variable for the factorial calculation
            if (isValidData())
            {
                int numberValue = Int32.Parse(txtNumInput.Text);
                for (int i = 1; i <= numberValue; i++)
                {
                    factorialCalculatedValuse *= i;
                }
                //Setting the value of the calculated factorial
                lblFactorialCalculate.Text = factorialCalculatedValuse.ToString("n0");
            }
        }
        // An event handler that exit the form when clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
            this.Close();
        }

        //A method that check to see if the number is an integer and if it's from 1-20
        private bool isInteger(TextBox textBox, String name)
        {
            try
            {
                //A method that checks to see if the number is between 1-20
                if (Double.Parse(textBox.Text) > 0 && Double.Parse(textBox.Text)<=20)
                {
                    return true;
                }
                    else
                    {
                    //If the number isn't above twenty, display a message seeing the user should enter number between 1-20
                        MessageBox.Show(name + " must be a number between 1-20", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox.Clear();
                        textBox.Focus();
                        return false;
                    }



                }catch(FormatException)
            {
                //If the user enter a string, show a message telling them to enter a number
                MessageBox.Show(name + " shouln't be characters", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
                textBox.Focus();
                return false;
            }
                
        }

        //A method that checks to see if the textbox is empty
        private bool isPresent(TextBox textBox, String name)
        {
            
            if(textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
                textBox.Focus();
                return false;
            }
            return true;
        }
        
        //A method that checks to make sure that the data enter is valid, returns trues if data is valid
        private bool isValidData()
        {
            if (!isPresent(txtNumInput, "Number"))
                return false;
            if (!isInteger(txtNumInput, "Number"))
                return false;
            return true;
           
        }
        //A method that clears various controls.
        private void ClearTextBox()
        {
            txtNumInput.Clear();
            lblFactorialCalculate.Text = "";
            
        }
        //A event handler that clears the various controls
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
    }
}
