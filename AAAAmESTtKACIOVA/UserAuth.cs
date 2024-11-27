using System.Data.SqlClient;

public class UserAuth
{
    public bool CheckUserCredentials(string login, string password)
    {
        try
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                string connString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = mEST; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand($"select * from [users] where login = '{login}' and pass = '{password}'", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        catch
        {
            return false;
        }
    }
}
