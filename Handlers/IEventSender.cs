using Store.Commands;

namespace Store.Handlers
{
    public interface IEventSender
    {
        public void Send(EmailSendCommand command); 
    }
}
