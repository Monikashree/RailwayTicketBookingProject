using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Project
{
    class DBSQLServerUtils
    {   
        public static SqlConnection GetDBConnection(string datasource, string database,
            string userName, string password)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
            if (connection == null)
            {
                Console.WriteLine("Null in the data");

            }
            SqlConnection sqlConnection = new SqlConnection(connection);
            return sqlConnection;
        }

    }
}
