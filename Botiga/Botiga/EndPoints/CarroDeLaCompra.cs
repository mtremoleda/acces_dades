using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;


namespace Botiga.EndPoints;

public static class EndpointsCarroDeLaCompra
{
    public static void MapCarroDeLaCompraEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /carrosdelacompra
        app.MapGet("/carrosdelacompra", () =>
        {
            List<CarroDeLaCompra> carrosdelacompra = CarroDeLaCompraADO.GetAll(dbConn);
            return Results.Ok(carrosdelacompra);
        });

        // GET CarroDeLaCompra by id
        app.MapGet("/carrosdelacompra/{id}", (Guid id) =>
        {
            CarroDeLaCompra carrosdelacompra = CarroDeLaCompraADO.GetById(dbConn, id);

            return carrosdelacompra is not null
                ? Results.Ok(carrosdelacompra)
                : Results.NotFound(new { message = $"Carro de la compra with Id {id} not found." });

            // if (product is not null)
            // {
            //     return Results.Ok(product);
            // }
            // else
            // {
            //     return Results.NotFound(new { message = $"Product with Id {id} not found." });
            // }
        });




        // POST /carrosdelacompra
        app.MapPost("/carrosdelacompra", (CarroDeLaCompraRequest req) =>
        {
            CarroDeLaCompra carrosdelacompra = new CarroDeLaCompra
            {
                Id = Guid.NewGuid(),
                IdCarro = req.IdCarro,
                IdProduct = req.IdProduct,
                Preu = req.Preu,
                Quantitat = req.Quantitat
            };

            CarroDeLaCompraADO.Insert(dbConn, carrosdelacompra);

            return Results.Created($"/carrosdelacompra/{carrosdelacompra.Id}", carrosdelacompra);
        });

        // GET CarroDeLaCompra amb preu
        app.MapGet("/carrosdelacompra/{id}/import", (Guid id) =>
        {
            List<CarroDeLaCompra> llista = CarroDeLaCompraADO.GetAllProductsCarro(dbConn, id);






            return Results.Ok(llista);
        });





    }


}

public record CarroDeLaCompraRequest(Guid IdCarro, Guid IdProduct,int Preu, int Quantitat);  // Com ha de llegir el POST