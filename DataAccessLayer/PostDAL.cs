using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class PostDAL
    {
        private static string connectionString =
    @"Data Source=(LocalDB)\MSSQLLocalDB;
      Initial Catalog=AdvanceProject;
      Integrated Security=True;";

        // Make connectionString static
      

        public bool CreatePost(Post post)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Posts (UserId, Content, CreatedAt) VALUES (@UserId, @Content, @CreatedAt)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", post.UserId);
                    cmd.Parameters.AddWithValue("@Content", post.Content);
                    cmd.Parameters.AddWithValue("@CreatedAt", post.CreatedAt);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating post: {ex.Message}");
                return false;
            }
        }

        public List<Post> GetUserPosts(int userId)
        {
            List<Post> posts = new List<Post>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT p.PostId, p.UserId, p.Content, p.CreatedAt, u.Username 
                                   FROM Posts p
                                   INNER JOIN Users u ON p.UserId = u.UserId
                                   WHERE p.UserId = @UserId
                                   ORDER BY p.CreatedAt DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        posts.Add(new Post
                        {
                            PostId = (int)reader["PostId"],
                            UserId = (int)reader["UserId"],
                            Username = reader["Username"].ToString(),
                            Content = reader["Content"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting user posts: {ex.Message}");
            }
            return posts;
        }

        public List<Post> GetFriendsPosts(int userId)
        {
            List<Post> posts = new List<Post>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT p.PostId, p.UserId, p.Content, p.CreatedAt, u.Username 
                                   FROM Posts p
                                   INNER JOIN Users u ON p.UserId = u.UserId
                                   INNER JOIN Friendships f ON 
                                       (f.UserId = @UserId AND f.FriendId = p.UserId) 
                                       OR (f.FriendId = @UserId AND f.UserId = p.UserId)
                                   ORDER BY p.CreatedAt DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        posts.Add(new Post
                        {
                            PostId = (int)reader["PostId"],
                            UserId = (int)reader["UserId"],
                            Username = reader["Username"].ToString(),
                            Content = reader["Content"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting friends' posts: {ex.Message}");
            }
            return posts;
        }

        public bool DeletePost(int postId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Posts WHERE PostId = @PostId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PostId", postId);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting post: {ex.Message}");
                return false;
            }
        }

        // Static method for direct use
        public static bool CreatePost(int userId, string content)
        {
            string query = @"INSERT INTO Posts (UserId, Content, CreatedAt) 
                           VALUES (@UserId, @Content, GETDATE())";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Content", content);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error creating post: " + ex.Message);
                return false;
            }
        }

        public static bool DeletePost(int postId, int userId)
        {
            string query = "DELETE FROM Posts WHERE PostId = @PostId AND UserId = @UserId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PostId", postId);
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting post: " + ex.Message);
                return false;
            }
        }

        public static bool EditPost(int postId, int userId, string newContent)
        {
            string query = "UPDATE Posts SET Content = @Content WHERE PostId = @PostId AND UserId = @UserId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PostId", postId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Content", newContent);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error editing post: " + ex.Message);
                return false;
            }
        }

        public static Post GetPostById(int postId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT p.PostId, p.UserId, p.Content, p.CreatedAt, u.Username 
                                   FROM Posts p
                                   INNER JOIN Users u ON p.UserId = u.UserId
                                   WHERE p.PostId = @PostId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PostId", postId);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Post
                                {
                                    PostId = (int)reader["PostId"],
                                    UserId = (int)reader["UserId"],
                                    Username = reader["Username"].ToString(),
                                    Content = reader["Content"].ToString(),
                                    CreatedAt = (DateTime)reader["CreatedAt"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting post: " + ex.Message);
            }
            return null;
        }
    }
}