using Botiga.Domain.Entities;
using Botiga.Model;
using Botiga.Services;
using Microsoft.Data.SqlClient;
using static System.Console;

namespace Botiga.Repository
{
    class RolsADO
    {


       
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
