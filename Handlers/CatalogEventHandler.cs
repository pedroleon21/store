using Store.Data;
using Store.Models;

namespace Store.Handlers
{
    public class CatalogEventHandler : ICatalogEventHandler
    {
        private IEmailSender emailSender;
        public CatalogEventHandler(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public void Handler(Produto produto, IEnumerable<string> emails)
        {
            foreach (var email in emails)
            {
                emailSender.SendEmailAsync(email, "Novo Produto",$"Produto {produto.Nome} cadastrado");
            }
        }
    }
}
