using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AAAAmESTtKACIOVA
{
        public class UserAuth
        {
            public bool CheckUserCredentials(string login, string password)
            {
                string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mEST;"; using (SqlConnection sqlConnection = new SqlConnection(connString))
                {
                    sqlConnection.Open();
                    string query = "SELECT COUNT(*) FROM [users] WHERE login = @login AND pass = @password"; using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@login", login);
                        sqlCommand.Parameters.AddWithValue("@password", password);
                        int count = (int)sqlCommand.ExecuteScalar(); return count > 0;
                        return true;
                    }
                }
            }
        }
    }

