namespace MessageProject.Models
{
    public class SendMessageModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public int senderıd { get; set; }
        public int receiverıd { get; set; }
    }
}
