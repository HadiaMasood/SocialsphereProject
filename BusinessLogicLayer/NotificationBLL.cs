using DataAccessLayer;
using Models.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.BusinessLogicLayer
{
    public class NotificationBLL
    {
        public static bool CreateNotification(int userId, int triggeredByUserId, string notificationType, string message, int relatedPostId = 0)
        {
            if (string.IsNullOrWhiteSpace(message))
                return false;

            return NotificationDAL.CreateNotification(userId, triggeredByUserId, notificationType, message, relatedPostId);
        }

        public static List<Notification> GetUserNotifications(int userId)
        {
            return NotificationDAL.GetUserNotifications(userId);
        }

        public static int GetUnreadNotificationCount(int userId)
        {
            return NotificationDAL.GetUnreadNotificationCount(userId);
        }

        public static bool MarkAsRead(int notificationId)
        {
            return NotificationDAL.MarkAsRead(notificationId);
        }

        public static bool DeleteNotification(int notificationId)
        {
            return NotificationDAL.DeleteNotification(notificationId);
        }
    }
}
