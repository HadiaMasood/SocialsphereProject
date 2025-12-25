using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class NotificationDAL
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AdvanceProject;Integrated Security=True;";

        public static bool CreateNotification(int userId, int triggeredByUserId, string notificationType, string message, int relatedPostId = 0)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Notifications (UserId, TriggeredByUserId, NotificationType, Message, RelatedPostId, CreatedAt, IsRead)
                        VALUES (@UserId, @TriggeredByUserId, @NotificationType, @Message, @RelatedPostId, @CreatedAt, 0)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@TriggeredByUserId", triggeredByUserId);
                        cmd.Parameters.AddWithValue("@NotificationType", notificationType);
                        cmd.Parameters.AddWithValue("@Message", message);
                        cmd.Parameters.AddWithValue("@RelatedPostId", relatedPostId > 0 ? relatedPostId : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in CreateNotification: " + ex.Message);
            }
            return false;
        }

        public static List<Notification> GetUserNotifications(int userId)
        {
            List<Notification> notifications = new List<Notification>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT n.NotificationId, n.UserId, n.TriggeredByUserId, u.Username as TriggeredByUsername,
                               n.NotificationType, n.Message, n.RelatedPostId, n.CreatedAt, n.IsRead
                        FROM Notifications n
                        JOIN Users u ON n.TriggeredByUserId = u.UserId
                        WHERE n.UserId = @UserId
                        ORDER BY n.CreatedAt DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                notifications.Add(new Notification
                                {
                                    NotificationId = (int)reader["NotificationId"],
                                    UserId = (int)reader["UserId"],
                                    TriggeredByUserId = (int)reader["TriggeredByUserId"],
                                    TriggeredByUsername = reader["TriggeredByUsername"].ToString(),
                                    NotificationType = reader["NotificationType"].ToString(),
                                    Message = reader["Message"].ToString(),
                                    RelatedPostId = reader["RelatedPostId"] != DBNull.Value ? (int)reader["RelatedPostId"] : 0,
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    IsRead = (bool)reader["IsRead"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetUserNotifications: " + ex.Message);
            }
            return notifications;
        }

        public static int GetUnreadNotificationCount(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Notifications WHERE UserId = @UserId AND IsRead = 0";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetUnreadNotificationCount: " + ex.Message);
            }
            return 0;
        }

        public static bool MarkAsRead(int notificationId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Notifications SET IsRead = 1 WHERE NotificationId = @NotificationId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NotificationId", notificationId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in MarkAsRead: " + ex.Message);
            }
            return false;
        }

        public static bool DeleteNotification(int notificationId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Notifications WHERE NotificationId = @NotificationId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NotificationId", notificationId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in DeleteNotification: " + ex.Message);
            }
            return false;
        }
    }
}
