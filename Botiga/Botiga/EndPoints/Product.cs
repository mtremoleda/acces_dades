using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;


namespace Botiga.EndPoints;

public static class Endpoints
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /products
        app.MapGet("/products", () =>
        {
            List<ProductADO> products = ProductADO.GetAll(dbConn);
            return Results.Ok(products);
        });

        // GET Product by id
        app.MapGet("/products/{id}", (Guid id) =>
        {
            ProductADO product = ProductADO.GetById(dbConn, id);

            return product is not null
                ? Results.Ok(product)
                : Results.NotFound(new { message = $"Product with Id {id} not found." });

            // if (product is not null)
            // {
            //     return Results.Ok(product);
            // }
            // else
            // {
            //     return Results.NotFound(new { message = $"Product with Id {id} not found." });
            // }
        });




        // POST /products
        app.MapPost("/products", (ProductRequest req) =>
        {
            ProductADO productADO = new ProductADO
            {
                Id = Guid.NewGuid(),
                Code = req.Code,
                Name = req.Name,
                Price = req.Price
            };

            productADO.Insert(dbConn);

            return Results.Created($"/products/{productADO.Id}", productADO);
        });
    }


}

public record ProductRequest(string Code, string Name, decimal Price);  // Com ha de llegir el POST