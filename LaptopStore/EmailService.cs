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

        public async void HandleNewOrder(object sender, Order order)
        {
            string orderSummary = order.GetOrderSummary();
            await SendEmailAsync(order.CustomerEmail, "New Order Received", $"New order received:\n{orderSummary}");
        }

        public void Subscribe(Order order)
        {
            order.OrderChanged += HandleNewOrder;
        }

        public void Unsubscribe(Order order)
        {
            order.OrderChanged -= HandleNewOrder;
        }

        private async Task SendEmailAsync(string toAddress, string subject, string body)
        {
            try
            {
                MessageBox.Show("Order has been created.\nAn Email has been sent to you.\nPlease check your E-mail.");
                // Retrieve secrets from Azure Key Vault
                KeyVaultSecret emailUsername = secretClient.GetSecret("smtp-email");
                KeyVaultSecret emailPassword = secretClient.GetSecret("smtp-password");

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
                    await smtp.SendMailAsync(message); // Asynchronously send the email
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
                // Optionally, log the error to a file or monitoring system
            }
        }
    }
}
