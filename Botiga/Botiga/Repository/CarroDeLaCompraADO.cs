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

            string sql = @"INSERT INTO CarroDeLaCompra (Id, IdCarro, IdProduct, Quantitat)
                        VALUES (@Id, @IdCarro, @IdProduct, @Quantitat)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", carrodelacompra.Id);
            cmd.Parameters.AddWithValue("@IdCarro", carrodelacompra.IdCarro);
            cmd.Parameters.AddWithValue("@IdProduct", carrodelacompra.IdProduct);
            cmd.Parameters.AddWithValue("@Quantitat", carrodelacompra.Quantitat);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<CarroDeLaCompra> GetAll(DatabaseConnection dbConn)
        {
            List<CarroDeLaCompra> carrosdelacompra = new();

            dbConn.Open();
            string sql = "SELECT Id, IdCarro, IdProduct, Quantitat FROM CarroDeLaCompra";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                carrosdelacompra.Add(new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetGuid(1).ToString(),
                    IdProduct = reader.GetGuid(2).ToString(),
                    Quantitat = reader.GetInt32(3)
                });
            }

            dbConn.Close();
            return carrosdelacompra;
        }

        public static CarroDeLaCompra? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, IdCarro, IdProduct, Quantitat FROM CarroDeLaCompra WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            CarroDeLaCompra? carrodelacompra = null;

            if (reader.Read())
            {
                carrodelacompra = new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetGuid(1).ToString(),
                    IdProduct = reader.GetGuid(2).ToString(),
                    Quantitat = reader.GetInt32(3)
                };
            }

            dbConn.Close();
            return carrodelacompra;
        }
    }
}
