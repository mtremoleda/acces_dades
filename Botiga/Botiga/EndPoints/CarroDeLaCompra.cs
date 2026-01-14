using Botiga.Classes;
using Botiga.Descomptes;
using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;


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
        app.MapGet("/carrodelacompra/{id}/import", (Guid id, string tipusClient) =>
        {
            List<CarroDeLaCompra> llista = CarroDeLaCompraADO.GetAllProductsCarro(dbConn, id)!;


            //Calcular import quantitat * preu
            decimal import = CalculsCarroDeLaCompra.CalcularImport(llista);


            IDescompteFactory dteFactory = tipusClient switch
            {
                "Estandard" => new DescompteEstandarFactory(),
                "Premium" => new DescomptePremiumFactory(),
                _ => throw new ArgumentException("Tipus de client desconegut.")
            };

            IDescompte descompte = dteFactory.CreateDescompte();
            decimal dte = descompte.CalcularDte(import);

            decimal importFinal = import - dte;


            //Calcular descompte //crear descompte per determinar


            
            return Results.Ok(importFinal);
            //Retornar import, Descompte, Import amb descompte
            //return Results.Ok(llista);
        });

    }


}

public record CarroDeLaCompraRequest(Guid IdCarro, Guid IdProduct,int Preu, int Quantitat);  // Com ha de llegir el POST