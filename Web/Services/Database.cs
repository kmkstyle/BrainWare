using System.Configuration;
using System.Data;

namespace Web.Services
{
    /// <summary>
    /// Database class
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        /// Connection name
        /// </summary>
        public string ConnectionName => "brainWare";

        /// <summary>
        /// Connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Get the configuration connection string
        /// </summary>
        /// <param name="connectionName">Connection name</param>
        /// <returns>Connection string</returns>
        public string GetConfigurationConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        /// <summary>
        /// Create database connection
        /// </summary>
        /// <returns>Database connection</returns>
        public abstract IDbConnection CreateConnection();

        /// <summary>
        /// Create open database connection
        /// </summary>
        /// <returns>Database connection</returns>
        public abstract IDbConnection CreateOpenConnection();

        /// <summary>
        /// Create database command
        /// </summary>
        /// <returns>Database command</returns>
        public abstract IDbCommand CreateCommand();

        /// <summary>
        /// Create database command for the specified command text and database connection
        /// </summary>
        /// <param name="commandText">Command text</param>
        /// <param name="connection">Database connection</param>
        /// <returns>Database commmand</returns>
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);
    }
}