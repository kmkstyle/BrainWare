using System.Data;
using System.Data.SqlClient;

namespace Web.Services
{
    /// <summary>
    /// Sql database class
    /// </summary>
    public class SqlDatabase : Database
    {
        /// <summary>
        /// Create database connection
        /// </summary>
        /// <returns>Database connection</returns>
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection()
            {
                ConnectionString = GetConfigurationConnectionString(ConnectionName)
            };
        }

        /// <summary>
        /// Create open database connection
        /// </summary>
        /// <returns>Database connection</returns>
        public override IDbConnection CreateOpenConnection()
        {
            var connection = CreateConnection();
            connection.Open();
            return connection;
        }

        /// <summary>
        /// Create database command
        /// </summary>
        /// <returns>Database command</returns>
        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        /// <summary>
        /// Create database command for the specified command text and database connection
        /// </summary>
        /// <param name="commandText">Command text</param>
        /// <param name="connection">Database connection</param>
        /// <returns>Database commmand</returns>
        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            var command = CreateCommand();
            command.CommandText = commandText;
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            return command;
        }
    }
}