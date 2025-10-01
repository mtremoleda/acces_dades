using Microsoft.Data.SqlClient;
using static System.Console;
using Botiga.Services;

namespace Botiga.Repository
{
    class ProductADO
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal Price { get; set; }

        public void Insert(DatabaseConnection dbConn)
        {

            dbConn.Open();

            string sql = @"INSERT INTO Products (Id, Code, Name, Price)
                        VALUES (@Id, @Code, @Name, @Price)";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Price", Price);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"{rows} fila inserida.");
            dbConn.Close();
        }

        public static List<ProductADO> GetAll(DatabaseConnection dbConn)
        {
            List<ProductADO> products = new();

            dbConn.Open();
            string sql = "SELECT Id, Code, Name, Price FROM Products";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new ProductADO
                {
                    Id = reader.GetGuid(0),
                    Code = reader.GetString(1),
                    Name = reader.GetString(2),
                    Price = reader.GetDecimal(3)
                });
            }

            dbConn.Close();
            return products;
        }

        public static ProductADO? GetById(DatabaseConnection dbConn, Guid id)
        {
            dbConn.Open();
            string sql = "SELECT Id, Code, Name, Price FROM Products WHERE Id = @Id";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = cmd.ExecuteReader();
            ProductADO? product = null;

            if (reader.Read())
            {
                product = new ProductADO
                {
                    Id = reader.GetGuid(0),
                    Code = reader.GetString(1),
                    Name = reader.GetString(2),
                    Price = reader.GetDecimal(3)
                };
            }

            dbConn.Close();
            return product;
        }
    }
}
