using Microsoft.Data.SqlClient;
using static System.Console;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.Repository

{
     class CarroDeLaCompraADO
    {


        public static void Insert(DatabaseConnection dbConn, CarroDeLaCompra carrodelacompra)
        {

            dbConn.Open();

            string sql = @"INSERT INTO CarroDeLaCompra (Id, IdCarro, IdProducte, Quantitat)
                        VALUES (@Id, @IdCarro, @IdProducte, @Quantitat)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", carrodelacompra.Id);
            cmd.Parameters.AddWithValue("@IdCarro", carrodelacompra.IdCarro);
            cmd.Parameters.AddWithValue("@IdProducte", carrodelacompra.IdProducte);
            cmd.Parameters.AddWithValue("@Quantitat", carrodelacompra.Quantitat);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<CarroDeLaCompra> GetAll(DatabaseConnection dbConn)
        {
            List<CarroDeLaCompra> carrosdelacompra = new();

            dbConn.Open();
            string sql = "SELECT Id, IdCarro, IdProducte, Quantitat FROM CarroDeLaCompra";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                carrosdelacompra.Add(new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetString(1),
                    IdProducte = reader.GetString(2),
                    Quantitat = reader.GetInt32(3)
                });
            }

            dbConn.Close();
            return carrosdelacompra;
        }

        public static CarroDeLaCompra? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, IdCarro, IdProducte, Quantitat FROM CarroDeLaCompra WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            CarroDeLaCompra? carrodelacompra = null;

            if (reader.Read())
            {
                carrodelacompra = new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetString(1),
                    IdProducte = reader.GetString(2),
                    Quantitat = reader.GetInt32(3)
                };
            }

            dbConn.Close();
            return carrodelacompra;
        }
    }
}
