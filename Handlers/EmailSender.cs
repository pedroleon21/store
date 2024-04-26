
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

            string host = "localhost";
            int port = 1025;
            string fromAddress = "store@app.com";

            message.From = new MailAddress(fromAddress);

            using (var smtpClient = new SmtpClient(host, port))
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
