
using System.Net.Mail;

namespace Store.Handlers
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _config;
        public EmailSender(IConfiguration config)
        {
            _config = _config;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage message = new MailMessage();
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;
            message.To.Add(email);

            string host = _config.GetValue<string>("Smtp:Server", "defaultmailserver");
            int port = _config.GetValue<int>("Smtp:Port", 1025);
            string fromAddress = _config.GetValue<string>("Smtp:FromAddress", "defaultfromaddress");

            message.From = new MailAddress(fromAddress);

            using (var smtpClient = new SmtpClient(host, port))
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
