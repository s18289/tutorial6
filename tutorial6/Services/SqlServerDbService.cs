using System;
using System.Data.SqlClient;

namespace tutorial6.Services
{
    public class SqlServerDbService : IDbService
    {

        private readonly string connectionString = "Data Source=db-mssql;Initial Catalog=s18289;Integrated Security=True";

        public bool GetStudentByIndex(string Index)
        {
            using (var con = new SqlConnection(connectionString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT * FROM Student WHERE IndexNumber=@IndexNumber";
                com.Parameters.AddWithValue("IndexNumber", Index);
                con.Open();
                var dr = com.ExecuteReader();

                if (dr.Read())
                {
                    return true;
                }
                return false;
            }
        }
    }
}