using Botiga.Classes;
using Botiga.COMMON;
using Botiga.Descomptes;
using Botiga.Domain.Entities;
using Botiga.Domain.Validators;
using Botiga.DTO;
using Botiga.DTO.Compras;
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
            
            Compra compra = req.ToCompra();
            Result result = CompraValidator.Validate(compra);

            if (!result.IsOk)
            {
                return Results.BadRequest(new 
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }
            
            return Results.Ok(compra);
        });

        
       

    }


}

