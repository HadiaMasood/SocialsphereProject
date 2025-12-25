using System;

namespace Models.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public int TriggeredByUserId { get; set; }
        public string TriggeredByUsername { get; set; }
        public string NotificationType { get; set; } // "Like", "Comment", "FriendRequest", "Message"
        public int RelatedPostId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }

        public Notification()
        {
            CreatedAt = DateTime.Now;
            IsRead = false;
        }

        public Notification(int userId, int triggeredByUserId, string notificationType, string message)
        {
            UserId = userId;
            TriggeredByUserId = triggeredByUserId;
            NotificationType = notificationType;
            Message = message;
            CreatedAt = DateTime.Now;
            IsRead = false;
        }
    }
}
