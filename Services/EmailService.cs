using EmailAPI.Interfaces;
using System.Net;
using System.Net.Mail;

namespace EmailAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration config;
        public EmailService(IConfiguration config)
        {
            this.config = config;
        }

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            var email = config.GetValue<string>("EMAIL_CONFIG:EMAIL");
            var password = config.GetValue<string>("EMAIL_CONFIG:PASSWORD");
            var host = config.GetValue<string>("EMAIL_CONFIG:HOST");
            var port = config.GetValue<int>("EMAIL_CONFIG:PORT");

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(email, password);

            var mailMessage = new MailMessage(email, recipient, subject, body);
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
