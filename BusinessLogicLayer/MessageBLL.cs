using DataAccessLayer;
using Models.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.BusinessLogicLayer
{
    public class MessageBLL
    {
        public static bool SendMessage(int senderId, int receiverId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return false;

            if (senderId == receiverId)
                return false;

            return MessageDAL.SendMessage(senderId, receiverId, content);
        }

        public static List<Message> GetConversation(int userId1, int userId2)
        {
            return MessageDAL.GetConversation(userId1, userId2);
        }

        public static System.Data.DataTable GetUserConversations(int userId)
        {
            return MessageDAL.GetUserConversations(userId);
        }

        public static bool MarkAsRead(int messageId)
        {
            return MessageDAL.MarkAsRead(messageId);
        }
    }
}
