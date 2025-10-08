using Microsoft.Data.SqlClient;
using static System.Console;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.Repository
{
    class FamiliaADO
    {


        public static void Insert(DatabaseConnection dbConn, Familia familia)
        {

            dbConn.Open();

            string sql = @"INSERT INTO Familia (Id, Nom, Descripcio)
                        VALUES (@Id, @Nom, @Descripcio)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", familia.Id);
            cmd.Parameters.AddWithValue("@Nom", familia.Nom);
            cmd.Parameters.AddWithValue("@Descripcio", familia.Descripcio);
            

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<Familia> GetAll(DatabaseConnection dbConn)
        {
            List<Familia> familia = new();

            dbConn.Open();
            string sql = "SELECT Id, Nom, Descripcio FROM Familia";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                familia.Add(new Familia
                {
                    Id = reader.GetGuid(0),
                    Nom = reader.GetString(1),
                    Descripcio = reader.GetString(2),
                    
                });
            }

            dbConn.Close();
            return familia;
        }

        public static Familia? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, Nom, Descripcio FROM Familia WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            Familia? familia= null;

            if (reader.Read())
            {
                familia = new Familia
                {
                    Id = reader.GetGuid(0),
                    Nom = reader.GetString(1),
                    Descripcio = reader.GetString(2),
                   
                };
            }

            dbConn.Close();
            return familia;
        }
    }
}
