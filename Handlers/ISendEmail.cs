

namespace Store.Handlers
{
    public interface IEmailSender
    {
        
        public Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
