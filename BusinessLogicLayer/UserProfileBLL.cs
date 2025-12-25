using DataAccessLayer;
using Models.Models;

namespace BusinessLogicLayer.BusinessLogicLayer
{
    public class UserProfileBLL
    {
        public static UserProfile GetUserProfile(int userId)
        {
            return UserProfileDAL.GetUserProfile(userId);
        }

        public static bool UpdateUserProfile(int userId, string bio, string profilePicture)
        {
            if (string.IsNullOrWhiteSpace(bio))
                bio = "";

            return UserProfileDAL.UpdateUserProfile(userId, bio, profilePicture);
        }

        public static System.Data.DataTable SearchUsers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            return UserProfileDAL.SearchUsers(searchTerm);
        }

        public static System.Data.DataTable GetAllUsers()
        {
            return UserProfileDAL.GetAllUsers();
        }
    }
}
