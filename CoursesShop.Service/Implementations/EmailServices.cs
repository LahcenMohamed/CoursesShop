using CoursesShop.Service.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace CoursesShop.Service.Implementations
{
    public sealed class EmailServices(IConfiguration configuration) : IEmailServices
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<string> SendEmailAsync(string toEmail, string Message, string? reason)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailHost").Value));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = reason;
                email.Body = new TextPart(TextFormat.Text)
                {
                    Text = Message
                };

                using var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                await smtp.ConnectAsync(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Erorr: " + ex.Message;
            }

        }
    }
}
