using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Project
{
    class UserRepository
    {
        protected static List<User> userList = new List<User>();        //A static user list to store user details 
        SqlConnection sqlConnection = DBUtils.GetDBConnection();

        public void RegisterDetail(User user, SqlConnection sqlConnection)            //Method to make user to register with the account
        {
            using (SqlCommand sqlCommand = new SqlCommand("USER_ADMIN_Registration", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@firstname", user.firstName));
                sqlCommand.Parameters.Add(new SqlParameter("@lastname", user.lastName));
                sqlCommand.Parameters.Add(new SqlParameter("@dob", user.DOB));
                sqlCommand.Parameters.Add(new SqlParameter("@sex", user.sex));
                sqlCommand.Parameters.Add(new SqlParameter("@email", user.email));
                sqlCommand.Parameters.Add(new SqlParameter("@mobileno", user.mobileNum));
                sqlCommand.Parameters.Add(new SqlParameter("@password", user.password));
                sqlCommand.Parameters.Add(new SqlParameter("@role", user.role));
                int retRows = sqlCommand.ExecuteNonQuery();
                if (retRows >= 1)
                    Console.WriteLine(Writer.data);
                else
                    Console.WriteLine(Writer.noData);
                sqlCommand.Dispose();
            }
        }

        internal int VerifyWithDB(string userName, string passWord)
        {
                      
            using (SqlCommand sqlCommand = new SqlCommand("spCHECKDB", sqlConnection))
            {
                SqlParameter sqlParameter = new SqlParameter();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@firstname", userName);
                sqlCommand.Parameters.AddWithValue("@password", passWord);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int, 3);
                sqlCommand.Parameters["@id"].Direction = ParameterDirection.Output;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();              
                int ID = Convert.ToInt32(sqlCommand.Parameters["@id"].Value);
                sqlConnection.Close();
                return ID;
               
            }
        }

        internal string FetchRole(int ID)
        {
            using (SqlCommand sqlCommand = new SqlCommand("spFETCHROLE", sqlConnection))
            {
                SqlParameter sqlParameter = new SqlParameter();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", ID);                
                sqlCommand.Parameters.Add("@role", SqlDbType.VarChar, 6);
                sqlCommand.Parameters["@role"].Direction = ParameterDirection.Output;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                string role = Convert.ToString(sqlCommand.Parameters["@role"].Value);
                sqlConnection.Close();
                return role;
            }
        }
        
        
    }
}
 