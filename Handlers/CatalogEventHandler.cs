using Store.Commands;
using Store.Data;
using Store.Models;

namespace Store.Handlers
{
    public class CatalogEventHandler : ICatalogEventHandler
    {
        private IEventSender eventSender;
        public CatalogEventHandler(IEventSender eventSender)
        {
            this.eventSender =eventSender;
        }

        public void Handler(Produto produto, IEnumerable<string> emails)
        {
            foreach (var email in emails)
            {
                eventSender.Send(new EmailSendCommand {
                    To= email,
                    Subject=  "Novo Produto",
                    Body= $"Produto {produto.Nome} cadastrado"
                });
            }
        }
    }
}
