using DataAccessLayer;
using Models;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        /// <summary>
        /// Check if username already exists
        /// </summary>
        public static bool UsernameExists(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            try
            {
                User user = UserDAL.GetUserByUsername(username);
                return user != null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error checking username: " + ex.Message);
                throw new Exception("Error checking username: " + ex.Message);
            }
        }

        /// <summary>
        /// Check if email already exists
        /// </summary>
        public static bool EmailExists(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                User user = UserDAL.GetUserByEmail(email);
                return user != null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error checking email: " + ex.Message);
                throw new Exception("Error checking email: " + ex.Message);
            }
        }

        /// <summary>
        /// SignUp method - Create new user account
        /// </summary>
        public static bool SignUp(string email, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                // Check if username already exists
                if (UsernameExists(username))
                {
                    System.Diagnostics.Debug.WriteLine("Username already exists: " + username);
                    return false;
                }

                // Check if email already exists
                if (EmailExists(email))
                {
                    System.Diagnostics.Debug.WriteLine("Email already exists: " + email);
                    return false;
                }

                // Create account using AddUser
                return UserDAL.AddUser(username, email, password);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error during signup: " + ex.Message);
                throw new Exception("Error during signup: " + ex.Message);
            }
        }

        /// <summary>
        /// Login method - Authenticate user
        /// </summary>
        public static User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            try
            {
                // GetUser returns User object or null
                return UserDAL.GetUser(username, password);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error during login: " + ex.Message);
                throw new Exception("Error during login: " + ex.Message);
            }
        }

        /// <summary>
        /// Get all active users (for admin panel)
        /// </summary>
        public static DataTable GetAllUsers()
        {
            try
            {
                return UserDAL.GetAllUsers();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting all users: " + ex.Message);
                throw new Exception("Error getting all users: " + ex.Message);
            }
        }

        /// <summary>
        /// Delete user (soft delete)
        /// </summary>
        public static bool DeleteUser(int userId)
        {
            if (userId <= 0)
                return false;

            try
            {
                return UserDAL.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting user: " + ex.Message);
                throw new Exception("Error deleting user: " + ex.Message);
            }
        }

        /// <summary>
        /// Search users by username or email
        /// </summary>
        public static DataTable SearchUsers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new DataTable();

            try
            {
                return UserDAL.SearchUsers(searchTerm);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error searching users: " + ex.Message);
                throw new Exception("Error searching users: " + ex.Message);
            }
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        public static User GetUserById(int userId)
        {
            if (userId <= 0)
                return null;

            try
            {
                return UserDAL.GetUserById(userId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting user by ID: " + ex.Message);
                throw new Exception("Error getting user by ID: " + ex.Message);
            }
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        public static User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            try
            {
                return UserDAL.GetUserByUsername(username);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting user by username: " + ex.Message);
                throw new Exception("Error getting user by username: " + ex.Message);
            }
        }

        /// <summary>
        /// Validate user credentials
        /// </summary>
        public static bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                return UserDAL.CheckUser(username, password);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error validating user: " + ex.Message);
                throw new Exception("Error validating user: " + ex.Message);
            }
        }
    }
}