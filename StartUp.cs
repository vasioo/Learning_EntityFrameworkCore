using System;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET_exercises
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection =
                new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();
            string res = GetVillainNamesAndMinionsCount(sqlConnection);
            Console.WriteLine(res);
            sqlConnection.Close();
        }
        private static string GetVillainNamesAndMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();
            string query = @" SELECT 
                                v.Name, COUNT(mv.VillainId) AS MinionsCount
                                  FROM Villains AS v
                                  JOIN MinionsVillains AS mv 
                                  ON v.Id = mv.VillainId
                                GROUP BY v.Id, v.Name
                                  HAVING COUNT(mv.VillainId) > 3
                                ORDER BY COUNT(mv.VillainId)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sb.Append($"{reader["Name"]} - {reader["MinionsCount"]}");
            }
            return sb.ToString().TrimEnd();
            
        }
    }
}
