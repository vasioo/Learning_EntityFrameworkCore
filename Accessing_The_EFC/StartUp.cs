using System;
using System.Data.SqlClient;

namespace Accessing_the_EFC
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection =
                new SqlConnection(Config.ConnectionString);

            sqlConnection.Open();

            string employeeCountQuery = "SELECT COUNT(*)" +
                                          " AS [EmployeeCount]" +
                                          " FROM [Employees]";
            SqlCommand sqlCommand = 
                new SqlCommand(employeeCountQuery, sqlConnection);

            int employeeCount = (int)sqlCommand.ExecuteScalar();
            Console.WriteLine("Employees available: "+employeeCount);

            string employeeInfoQuery = @"SELECT
                                        [FirstName]
                                        ,[LastName]
                                        ,[JobTitle]
                                        FROM [Employees]";
            SqlCommand employeeInfoCommand =
                new SqlCommand(employeeInfoQuery,sqlConnection);
            using SqlDataReader employeeInfoReader = 
                employeeInfoCommand.ExecuteReader();
            int rowNumber = 1;
            while (employeeInfoReader.Read())//chetem go cus' indeksaciqta e razlichna
            {
                string firstName =(string)employeeInfoReader["FirstName"];
                string lastName =(string)employeeInfoReader["LastName"];
                string jobTitle =(string)employeeInfoReader["JobTitle"];
                Console.WriteLine($"##{rowNumber++}. {firstName} {lastName} - {jobTitle}");
            }
            employeeInfoReader.Close();
        }
    }
}