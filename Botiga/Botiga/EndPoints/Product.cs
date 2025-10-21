using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.EndPoints
{
    public static class EndpointsProduct
    {
        public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
        {
            // GET /product
            app.MapGet("/product", () =>
            {
                List<Product> products = ProductADO.GetAll(dbConn);
                return Results.Ok(products);
            });

            // GET /product/{id}
            app.MapGet("/product/{id}", (Guid id) =>
            {
                Product product = ProductADO.GetById(dbConn, id)!;

                return product is not null
                    ? Results.Ok(product)
                    : Results.NotFound(new { message = $"Product with Id {id} not found." });
            });

            // POST /product
            app.MapPost("/product", (ProductRequest req) =>
            {
                Product product = new Product
                {
                    Id = Guid.NewGuid(),
                    Nom = req.Nom,
                    Descripcio = req.Descripcio,
                    Preu = req.Preu,
                    Descompte = req.Descompte
                };

                ProductADO.Insert(dbConn, product);

                return Results.Created($"/product/{product.Id}", product);
            });
        }
    }

    
    public record ProductRequest(string Nom, string Descripcio, decimal Preu, int Descompte);
}
