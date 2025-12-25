using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class MessageDAL
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AdvanceProject;Integrated Security=True;";

        public static bool SendMessage(int senderId, int receiverId, string content)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Messages (SenderId, ReceiverId, Content, CreatedAt, IsRead)
                        VALUES (@SenderId, @ReceiverId, @Content, @CreatedAt, 0)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SenderId", senderId);
                        cmd.Parameters.AddWithValue("@ReceiverId", receiverId);
                        cmd.Parameters.AddWithValue("@Content", content);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in SendMessage: " + ex.Message);
            }
            return false;
        }

        public static List<Message> GetConversation(int userId1, int userId2)
        {
            List<Message> messages = new List<Message>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT m.MessageId, m.SenderId, m.ReceiverId, u1.Username as SenderUsername, 
                               u2.Username as ReceiverUsername, m.Content, m.CreatedAt, m.IsRead
                        FROM Messages m
                        JOIN Users u1 ON m.SenderId = u1.UserId
                        JOIN Users u2 ON m.ReceiverId = u2.UserId
                        WHERE (m.SenderId = @UserId1 AND m.ReceiverId = @UserId2)
                           OR (m.SenderId = @UserId2 AND m.ReceiverId = @UserId1)
                        ORDER BY m.CreatedAt ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId1", userId1);
                        cmd.Parameters.AddWithValue("@UserId2", userId2);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                messages.Add(new Message
                                {
                                    MessageId = (int)reader["MessageId"],
                                    SenderId = (int)reader["SenderId"],
                                    ReceiverId = (int)reader["ReceiverId"],
                                    SenderUsername = reader["SenderUsername"].ToString(),
                                    ReceiverUsername = reader["ReceiverUsername"].ToString(),
                                    Content = reader["Content"].ToString(),
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
                System.Diagnostics.Debug.WriteLine("Error in GetConversation: " + ex.Message);
            }
            return messages;
        }

        public static DataTable GetUserConversations(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT DISTINCT 
                            CASE WHEN SenderId = @UserId THEN ReceiverId ELSE SenderId END as OtherUserId,
                            CASE WHEN SenderId = @UserId THEN (SELECT Username FROM Users WHERE UserId = ReceiverId) 
                                 ELSE (SELECT Username FROM Users WHERE UserId = SenderId) END as OtherUsername,
                            MAX(CreatedAt) as LastMessageTime
                        FROM Messages
                        WHERE SenderId = @UserId OR ReceiverId = @UserId
                        GROUP BY CASE WHEN SenderId = @UserId THEN ReceiverId ELSE SenderId END
                        ORDER BY MAX(CreatedAt) DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetUserConversations: " + ex.Message);
            }
            return null;
        }

        public static bool MarkAsRead(int messageId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Messages SET IsRead = 1 WHERE MessageId = @MessageId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MessageId", messageId);
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
    }
}
