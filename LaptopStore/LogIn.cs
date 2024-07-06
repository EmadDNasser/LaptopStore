using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LaptopStore
{
    public partial class LogIn : Form
    {
        // Declare a delegate:
        public delegate void SendSignInof(object sender, string EmailID);

        // Declare an event using the delegate:
        public event SendSignInof SignInfoHandler;

        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            bool isValid = ValidateEmail(email);
            

            if (isValid)
            {
                SignInfoHandler?.Invoke(this, txtEmail.Text); // Trigger the event to send Sign in Info (Email ID) back to Main Form

                LblError.Text = "";
                LblError.Visible = false; // Hide the error label

                Close();
               
            }

            else
            {
                LblError.Text = "Invalid email format";
                LblError.Visible = true; // Make the error label visible
            }

        }

        private bool ValidateEmail(string email)
        {
            const string emailPattern = @"^(([^<>()\[\]\\.,;:\s@]+(\.[^<> ()\[\]\\.,;:\s@]+)*)|(.+ ))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }
    }
}
