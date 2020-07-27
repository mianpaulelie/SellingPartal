using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace WebServiceApp
{
    public class Users
    {
        public int IsAvailable(string UserName, string Email)
        {
            int UserID = 0;
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT UserID From Users where UserName=@UserName or Email=@Email");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    connection.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UserID = reader.GetInt32(0);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
               
            }
            return UserID;
        }

        public string GetLastToolAdded(string UserID, string DataAdded)
        {
            String ToolID = "0";
            try
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT ToolID From Users where UserName=@UserName or Email=@Email");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@UserName", UserID);
                    cmd.Parameters.AddWithValue("@Email", DataAdded);
                    connection.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ToolID = reader.GetString(0);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                
            }
            return ToolID;
        }
    }
}