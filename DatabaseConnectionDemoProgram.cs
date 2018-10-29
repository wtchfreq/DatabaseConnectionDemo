using System;
using System.Data.SqlClient;

namespace DatabaseConnectionDemo
{
    class DatabaseConnectionDemoProgram
    {

        static void Main(string[] args)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Server"] = @"IRWINE\SQLEXPRESS";
            builder["Database"] = @"COMPANY";
            builder["User Id"] = @"sharpdbacc";
            builder["Password"] = @"sharpdbacc";


            using (var conn = new SqlConnection(builder.ConnectionString))
            {
                var command = new SqlCommand("SELECT * FROM Employee", conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }

        }
    }
}
