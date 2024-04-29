namespace Store.Commands
{
    public class EmailSendCommand
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
    }
}
