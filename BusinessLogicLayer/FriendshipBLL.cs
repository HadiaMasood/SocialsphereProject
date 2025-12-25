using System;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer.BusinessLogicLayer
{
    public class FriendshipBLL
    {
        public static bool AddFriend(int userId, int friendUserId)
        {
            // Validation
            if (userId <= 0 || friendUserId <= 0)
                return false;

            if (userId == friendUserId)
                return false; // Can't befriend yourself

            // Check if already friends
            if (AreFriends(userId, friendUserId))
                return false;

            try
            {
                return FriendshipDAL.AddFriendship(userId, friendUserId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in AddFriend: " + ex.Message);
                return false;
            }
        }

        public static bool AreFriends(int userId1, int userId2)
        {
            if (userId1 <= 0 || userId2 <= 0)
                return false;

            try
            {
                return FriendshipDAL.CheckFriendship(userId1, userId2);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in AreFriends: " + ex.Message);
                return false;
            }
        }

        public static bool RemoveFriendship(int userId, int friendUserId)
        {
            if (userId <= 0 || friendUserId <= 0)
                return false;

            try
            {
                return FriendshipDAL.RemoveFriendship(userId, friendUserId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in RemoveFriendship: " + ex.Message);
                return false;
            }
        }

        public static int GetFriendCount(int userId)
        {
            try
            {
                return FriendshipDAL.GetFriendCount(userId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetFriendCount: " + ex.Message);
                return 0;
            }
        }
    }
}