using Botiga.Domain.Entities;
using Botiga.Model;
using Botiga.Services;
using Microsoft.Data.SqlClient;
using static System.Console;

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



        //INSERT PER ENTITY
        public static void InsertCarroDeLaCompraEntity(DatabaseConnection dbConn, CarroDeLaCompraEntity carrodelacompraentity)
        {
            dbConn.Open();

            string sql = @"INSERT INTO CarroDeLaCompra (Id, IdCarro, IdProduct, Quantitat, Preu)
                        VALUES (@Id, @IdCarro, @IdProduct, @Quantitat)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", carrodelacompraentity.Id);
            cmd.Parameters.AddWithValue("@IdCarro", carrodelacompraentity.IdCarro);
            cmd.Parameters.AddWithValue("@IdProduct", carrodelacompraentity.IdProduct);
            cmd.Parameters.AddWithValue("@Quantitat", carrodelacompraentity.Quantitat);
            cmd.Parameters.AddWithValue("@Preu", carrodelacompraentity.Preu);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }







        //public Guid Id { get; set; }
        //public Guid IdCarro { get; set; }
        //public Guid IdProduct { get; set; }
        //public decimal Preu { get; set; }
        //public int Quantitat { get; set; }


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
                    IdCarro = reader.GetGuid(1),
                    IdProduct = reader.GetGuid(2),
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
                    IdCarro = reader.GetGuid(1),
                    IdProduct = reader.GetGuid(2),
                    Quantitat = reader.GetInt32(3)
                    
                };
            }

            dbConn.Close();
            return carrodelacompra;
        }
        //Per aconseguir el preu 
        public static List<CarroDeLaCompra> GetAllProductsCarro(DatabaseConnection dbConn, Guid IdCarro)
        {
            List<CarroDeLaCompra> llista = new();
            dbConn.Open();
            string sql = "SELECT * FROM CarroDeLaCompra WHERE IdCarro = @IdCarro";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@IdCarro", IdCarro);

            using SqlDataReader reader = cmd.ExecuteReader();
            CarroDeLaCompra? carroCompra = null;

            while (reader.Read())
            {
                llista.Add (new CarroDeLaCompra
                {
                    Id = reader.GetGuid(0),
                    IdCarro = reader.GetGuid(1),
                    IdProduct = reader.GetGuid(2),
                    Quantitat = reader.GetInt32(3),
                    Preu = reader.GetDecimal(4)
                });
            }

            dbConn.Close();
            return llista;
        }

    }
}
