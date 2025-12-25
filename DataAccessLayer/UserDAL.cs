using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Models;

namespace DataAccessLayer
{
    public class UserDAL
    {
        private static string connectionString =
     @"Data Source=(LocalDB)\MSSQLLocalDB;
      Initial Catalog=AdvanceProject;
      Integrated Security=True;";

        /// Hash password using SHA256 for secure storage
        /// </summary>
        private static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        /// <summary>
        /// Verify if a password matches the stored hash
        /// </summary>
        private static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }

        /// <summary>
        /// Add a new user to the database
        /// </summary>
        public static bool AddUser(string username, string email, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string q = "INSERT INTO Users (Username, Email, Password, CreatedAt, IsActive) VALUES(@u, @e, @p, GETDATE(), 1)";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@u", username.Trim());
                    cmd.Parameters.AddWithValue("@e", email.Trim());
                    cmd.Parameters.AddWithValue("@p", HashPassword(password));

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Check if user credentials are valid
        /// </summary>
        public static bool CheckUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string q = "SELECT Password FROM Users WHERE Username=@n AND IsActive=1";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@n", username.Trim());
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string storedHash = result.ToString();
                        return VerifyPassword(password, storedHash);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error checking user: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get user by username and password
        /// </summary>
        public static User GetUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string q = "SELECT UserId, Username, Email FROM Users WHERE Username=@n AND IsActive=1";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@n", username.Trim());
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string storedHash = GetPasswordHash(username);
                        if (VerifyPassword(password, storedHash))
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Username = dr["Username"].ToString(),
                                Email = dr["Email"].ToString()
                            };
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting user: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get password hash for verification
        /// </summary>
        private static string GetPasswordHash(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string q = "SELECT Password FROM Users WHERE Username=@n AND IsActive=1";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@n", username.Trim());
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting password hash: " + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Get all active users for admin panel
        /// </summary>
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT UserId, Username, Email, CreatedAt, IsActive 
                             FROM Users 
                             WHERE IsActive = 1 
                             ORDER BY Username";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error fetching users: " + ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Search users by username or email
        /// </summary>
        public static DataTable SearchUsers(string searchTerm)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrWhiteSpace(searchTerm))
                return dt;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string q = "SELECT UserId, Username, Email FROM Users WHERE (Username LIKE @search OR Email LIKE @search) AND IsActive=1";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm.Trim() + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error searching users: " + ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Soft delete user by setting IsActive to 0
        /// </summary>
        public static bool DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string q = "UPDATE Users SET IsActive=0 WHERE UserId=@id";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@id", userId);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting user: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        public static User GetUserById(int userId)
        {
            string query = "SELECT UserId, Username, Email FROM Users WHERE UserId = @UserId AND IsActive=1";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting user by ID: " + ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        public static User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            string query = "SELECT UserId, Username, Email FROM Users WHERE Username = @Username AND IsActive = 1";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username.Trim());
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting user by username: " + ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Get user by email (NEW METHOD)
        /// </summary>
        public static User GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            string query = "SELECT UserId, Username, Email FROM Users WHERE Email = @Email AND IsActive = 1";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email.Trim());
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting user by email: " + ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Get user by email (NEW METHOD)
        /// </summary>
       
        /// <summary>
        /// Check if user is admin
        /// </summary>
        public static bool IsUserAdmin(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string q = "SELECT IsAdmin FROM Users WHERE UserId=@id AND IsActive=1";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@id", userId);
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToBoolean(result);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error checking admin status: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Validate user credentials
        /// </summary>
        public static bool ValidateUser(string username, string password)
        {
            return CheckUser(username, password);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        public static bool CreateUser(string username, string password, string email)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
                return false;

            string query = @"INSERT INTO Users (Username, Password, Email, CreatedAt, IsActive) 
                             VALUES (@Username, @Password, @Email, GETDATE(), 1)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username.Trim());
                        cmd.Parameters.AddWithValue("@Password", HashPassword(password));
                        cmd.Parameters.AddWithValue("@Email", email.Trim());
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error creating user: " + ex.Message);
                return false;
            }
        }
    }
}