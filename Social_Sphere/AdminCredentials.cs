using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Social_Sphere
{
    /// <summary>
    /// Static class for admin authentication
    /// Admin credentials should be stored in database with hashed passwords
    /// This class provides secure validation methods
    /// </summary>
    public static class AdminCredentials
    {
        /// <summary>
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
        /// Check if the provided credentials match admin credentials from database
        /// NOTE: Admin credentials should be stored in the Users table with IsAdmin flag
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <param name="password">Password to check</param>
        /// <returns>True if credentials are valid admin credentials, false otherwise</returns>
        public static bool IsAdminLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            // TODO: Implement database lookup for admin users
            // Query: SELECT * FROM Users WHERE Username = @username AND IsAdmin = 1
            // Then verify password hash
            // This prevents hardcoding credentials in source code
            
            return false; // Placeholder - implement with database lookup
        }

        /// <summary>
        /// Get list of all admin usernames (for reference only)
        /// </summary>
        /// <returns>List of admin usernames</returns>
        public static List<string> GetAdminUsernames()
        {
            // TODO: Implement database lookup
            // Query: SELECT Username FROM Users WHERE IsAdmin = 1
            return new List<string>();
        }

        /// <summary>
        /// Alternative method with case-insensitive username check
        /// </summary>
        public static bool IsAdminLoginCaseInsensitive(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            // TODO: Implement database lookup with case-insensitive username
            return false; // Placeholder - implement with database lookup
        }

        /// <summary>
        /// Method to get admin username for display purposes
        /// </summary>
        public static string GetAdminUsername()
        {
            // TODO: Return from database based on current logged-in admin
            return "Admin";
        }
    }
}
