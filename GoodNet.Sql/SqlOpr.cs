using System;
using GoodNet.Data.Models;
using Microsoft.Data.SqlClient;

namespace GoodNet.Sql
{
	public static class SqlOpr
	{
        public static MyInfo GetMyInfo()
		{
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = "Server=tcp:goodnet.database.windows.net,1433;Initial Catalog=goodnet;Persist Security Info=False;User ID=goodnetadmin;Password=Goodnet2023.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "SELECT * FROM dbo.MyInfo";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new MyInfo()
                                {
                                    Name = reader.GetString(0),
                                    Sex = reader.GetString(1),
                                    Phone = reader.GetString(2),
                                    Email = reader.GetString(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SqlOpr Error.", ex);
            }
            return new MyInfo();
        }
	}
}

