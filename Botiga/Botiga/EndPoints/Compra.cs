using Botiga.Classes;
using Botiga.Descomptes;
using Botiga.DTO;
using Botiga.DTO.Compra;
using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;


namespace Botiga.EndPoints;

public static class EndpointsCompra
{
    public static void MapCompraEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        




        // POST /carrosdelacompra
        app.MapPost("/compra", (CompraRequest req) =>
        {
            

            return Results.Ok(req.Productes);
        });

        
       

    }


}

