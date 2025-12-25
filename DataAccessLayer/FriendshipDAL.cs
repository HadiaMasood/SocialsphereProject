using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class FriendshipDAL
    {
        // Make connectionString static since all methods are static
        private static string connectionString =
     @"Data Source=(LocalDB)\MSSQLLocalDB;
      Initial Catalog=AdvanceProject;
      Integrated Security=True;";


        public static bool AddFriendship(int userId, int friendUserId)
        {
            string query = @"INSERT INTO Friendships (UserId, FriendId, CreatedAt) 
                           VALUES (@UserId, @FriendId, GETDATE())";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@FriendId", friendUserId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error adding friendship: " + ex.Message);
                return false;
            }
        }

        public static bool CheckFriendship(int userId1, int userId2)
        {
            string query = @"SELECT COUNT(*) FROM Friendships 
                           WHERE (UserId = @UserId1 AND FriendId = @UserId2) 
                           OR (UserId = @UserId2 AND FriendId = @UserId1)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId1", userId1);
                        cmd.Parameters.AddWithValue("@UserId2", userId2);

                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error checking friendship: " + ex.Message);
                return false;
            }
        }

        public static bool RemoveFriendship(int userId, int friendUserId)
        {
            string query = @"DELETE FROM Friendships 
                           WHERE (UserId = @UserId AND FriendId = @FriendId) 
                           OR (UserId = @FriendId AND FriendId = @UserId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@FriendId", friendUserId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error removing friendship: " + ex.Message);
                return false;
            }
        }

        public static DataTable GetUserFriends(int userId)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT DISTINCT u.UserId, u.Username, u.Email, u.FullName 
                           FROM Users u
                           INNER JOIN Friendships f ON 
                               (f.UserId = @UserId AND f.FriendId = u.UserId) 
                               OR (f.FriendId = @UserId AND f.UserId = u.UserId)
                           WHERE u.IsActive = 1
                           ORDER BY u.Username";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            conn.Open();
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting friends: " + ex.Message);
            }
            return dt;
        }

        public static int GetFriendCount(int userId)
        {
            string query = @"SELECT COUNT(DISTINCT 
                               CASE WHEN UserId = @UserId THEN FriendId 
                                    WHEN FriendId = @UserId THEN UserId 
                               END) 
                           FROM Friendships 
                           WHERE UserId = @UserId OR FriendId = @UserId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        conn.Open();
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting friend count: " + ex.Message);
                return 0;
            }
        }
    }
}