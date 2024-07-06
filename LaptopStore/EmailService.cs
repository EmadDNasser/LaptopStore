using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace LaptopStore
{
    internal class EmailService
    {
        private SecretClient secretClient;
      

        public EmailService()
        {
            
            secretClient = new SecretClient(new Uri("https://laptopstore.vault.azure.net/"), new DefaultAzureCredential());
        }

        public void HandleNewOrder(object sender, Order order)
        {
            string orderSummary = order.GetOrderSummary();
            SendEmail(order.CustomerEmail, "New Order Received", $"New order received:\n{orderSummary}");
        }

        public void Subscribe(Order order)
        {
            order.OrderChanged += HandleNewOrder;
        }

        public void Unsubscribe(Order order)
        {
            order.OrderChanged -= HandleNewOrder;
        }

        private async void SendEmail(string toAddress, string subject, string body)
        {


            try
            {
                // Retrieve secrets from Azure Key Vault
                KeyVaultSecret emailUsername = await secretClient.GetSecretAsync("smtp-email");
                KeyVaultSecret emailPassword = await secretClient.GetSecretAsync("smtp-password");

                var fromAddress = new MailAddress(emailUsername.Value, "Emad Nasser");
                var to = new MailAddress(toAddress);
                string fromPassword = emailPassword.Value; // Use the App Password generated in Google Account

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, to)
                {
                    Subject = subject,
                    Body = body
                })
                {
                  

                    await Task.Run(() => smtp.Send(message));

                    
                }

                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
                // Optionally, log the error to a file or monitoring system
            }
        }
    }
}
