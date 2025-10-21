using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;


namespace Botiga.EndPoints;

public static class EndpointsCarros
{
    public static void MapCarrosEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /Carros
        app.MapGet("/carros", () =>
        {
            List<Carros> carro = CarrosADO.GetAll(dbConn);
            return Results.Ok(carro);
        });

        // GET Carro by id
        app.MapGet("/carros/{id}", (Guid id) =>
        {
            Carros carro = CarrosADO.GetById(dbConn, id)!;

            return carro is not null
                ? Results.Ok(carro)
                : Results.NotFound(new { message = $"Carros with Id {id} not found." });


        });




        // POST /familia
        app.MapPost("/familia", (FamiliaRequest req) =>
        {
            Familia familia = new Familia
            {
                Id = Guid.NewGuid(),
                Nom = req.Nom,
                Descripcio = req.Descripcio,

            };

            FamiliaADO.Insert(dbConn, familia);

            return Results.Created($"/familia/{familia.Id}", familia);
        });
    }


}

public record FamiliaRequest(string Nom, string Descripcio);  // Com ha de llegir el POST