using Models.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UserProfileDAL
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AdvanceProject;Integrated Security=True;";

        public static UserProfile GetUserProfile(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT u.UserId, u.Username, u.Email, u.Bio, u.ProfilePicture, u.CreatedAt,
                               (SELECT COUNT(*) FROM Friendships WHERE FriendId = u.UserId) as FollowersCount,
                               (SELECT COUNT(*) FROM Friendships WHERE UserId = u.UserId) as FollowingCount,
                               (SELECT COUNT(*) FROM Posts WHERE UserId = u.UserId) as PostsCount
                        FROM Users u
                        WHERE u.UserId = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserProfile
                                {
                                    UserId = (int)reader["UserId"],
                                    Username = reader["Username"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Bio = reader["Bio"] != DBNull.Value ? reader["Bio"].ToString() : "",
                                    ProfilePicture = reader["ProfilePicture"] != DBNull.Value ? reader["ProfilePicture"].ToString() : "",
                                    FollowersCount = (int)reader["FollowersCount"],
                                    FollowingCount = (int)reader["FollowingCount"],
                                    PostsCount = (int)reader["PostsCount"],
                                    CreatedAt = (DateTime)reader["CreatedAt"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetUserProfile: " + ex.Message);
            }
            return null;
        }

        public static bool UpdateUserProfile(int userId, string bio, string profilePicture)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        UPDATE Users 
                        SET Bio = @Bio, ProfilePicture = @ProfilePicture
                        WHERE UserId = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Bio", bio ?? "");
                        cmd.Parameters.AddWithValue("@ProfilePicture", profilePicture ?? "");

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in UpdateUserProfile: " + ex.Message);
            }
            return false;
        }

        public static DataTable SearchUsers(string searchTerm)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT UserId, Username, Email, Bio, ProfilePicture
                        FROM Users
                        WHERE Username LIKE @SearchTerm OR Email LIKE @SearchTerm
                        ORDER BY Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in SearchUsers: " + ex.Message);
            }
            return null;
        }

        public static DataTable GetAllUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT UserId, Username, Email, Bio, ProfilePicture
                        FROM Users
                        ORDER BY Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetAllUsers: " + ex.Message);
            }
            return new DataTable();
        }
    }
}
