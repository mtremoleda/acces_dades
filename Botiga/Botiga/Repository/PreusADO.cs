using Botiga.Domain.Entities;
using Botiga.Model;
using Botiga.Services;
using Microsoft.Data.SqlClient;

namespace Botiga.Repository
{
    class PreusADO
    {

        public static Preus? GetPreu(DatabaseConnection dbConn, string idProduct)
        {
            dbConn.Open();
            string sql = "SELECT * FROM Preus WHERE IdProduct = @IdProduct";

            using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
            cmd.Parameters.AddWithValue("@IdProduct", idProduct);

            using SqlDataReader reader = cmd.ExecuteReader();
            Preus? preu = null;

            if (reader.Read())
            {
                preu = new Preus
                {
                    idProduct = reader.GetGuid(0),
                    data = DateOnly.FromDateTime(reader.GetDateTime(1)),
                    Preu = reader.GetDecimal(2)
                };
            }

            dbConn.Close();
            return preu;
        }
    }
}