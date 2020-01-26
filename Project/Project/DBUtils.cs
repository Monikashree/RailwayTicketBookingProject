using System;
using System.Data.SqlClient;

namespace Project
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"LENOVO\SQLEXPRESS";
            string database = "Railway";
            string userName = "sa";
            string password = "monika123";
            return DBSQLServerUtils.GetDBConnection(datasource, database, userName, password);
        }
    }
}
