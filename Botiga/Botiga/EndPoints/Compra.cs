using Botiga.Classes;
using Botiga.COMMON;
using Botiga.Descomptes;
using Botiga.Domain.Entities;
using Botiga.Domain.Validators;
using Botiga.DTO;
using Botiga.DTO.Compras;
using Botiga.Infraestructure.Mappers;
using Botiga.Model;
using Botiga.Repository;
using Botiga.Services;
using System.ComponentModel.DataAnnotations.Schema;


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
            

            
            Guid IdCarros = Guid.NewGuid();


            CarroEntity carroEntity = CarrosMapper.ToEntity(IdCarros, compra);

            CarrosADO.InsertCarrosEntity(dbConn, carroEntity);


            foreach (LineaProducte lp in compra.Productes)
            {
                Guid Id = Guid.NewGuid();
                Console.WriteLine(lp.producte.codi);
                Preus preu = PreusADO.GetPreu(dbConn, lp.producte.codi);
                Console.WriteLine(preu.Preu);

                CarroDeLaCompraEntity carroDeLaCompraEntity = CarroDeLaCompraMapper.ToEntity(Id, IdCarros, lp, preu);
                CarroDeLaCompraADO.InsertCarroDeLaCompraEntity(dbConn, carroDeLaCompraEntity);

            }

            //CarroDeLaCompraEntity carroDeLaCompraEntity = CarroDeLaCompraMapper.ToEntity(IdCarroDeLaCompra, compra);

            //return Results.Ok(compra);
            return Results.Ok(carroEntity);


        });

        
       

    }


}

