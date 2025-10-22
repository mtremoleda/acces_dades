using Microsoft.Data.SqlClient;
using static System.Console;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.Repository
{
    class CarrosADO
    {


        public static void Insert(DatabaseConnection dbConn, Carros carro)
        {

            dbConn.Open();

            string sql = @"INSERT INTO Carros (Id, Nom)
                        VALUES (@Id, @Nom)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", carro.Id);
            cmd.Parameters.AddWithValue("@Nom", carro.Nom);

            int rows = cmd.ExecuteNonQuery();

            
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<Carros> GetAll(DatabaseConnection dbConn)
        {
            List<Carros> carro = new();

            dbConn.Open();
            string sql = "SELECT Id, Nom FROM Carros";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                carro.Add(new Carros
                {
                    Id = reader.GetGuid(0),
                    Nom = reader.GetString(1),
                    
                });
            }

            dbConn.Close();
            return carro;
        }

        public static Carros? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, Nom FROM Carros WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            Carros? carro = null;

            if (reader.Read())
            {
                carro = new Carros
                {
                    Id = reader.GetGuid(0),
                    Nom = reader.GetString(1),
                 
                };
            }

            dbConn.Close();
            return carro;
        }
    }
}
