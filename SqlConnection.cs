using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANITARY
{
    internal class SqlConnection
    {
        string username = Environment.UserName;
        string desktopName = Environment.MachineName;


        // Define the connection string to the database
        string connectionString;


        public SqlConnection(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.GetConnection();
            return connection;
        }
    }
}
