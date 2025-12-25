using System;
using System.Configuration;

namespace Social_Sphere
{
    /// <summary>
    /// Centralized database configuration
    /// Connection strings should be stored in App.config, not hardcoded
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        /// Get connection string from App.config
        /// </summary>
        public static string GetConnectionString()
        {
            try
            {
                // Read from App.config
                string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
                
                if (string.IsNullOrEmpty(connString))
                {
                    // Fallback to local database if not configured
                    connString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AdvanceProject;Integrated Security=True;";
                }
                
                return connString;
            }
            catch
            {
                // Fallback connection string
                return @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AdvanceProject;Integrated Security=True;";
            }
        }
    }
}
