using System;

namespace Models.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }

        public Message()
        {
            CreatedAt = DateTime.Now;
            IsRead = false;
        }

        public Message(int senderId, int receiverId, string content)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            CreatedAt = DateTime.Now;
            IsRead = false;
        }
    }
}
