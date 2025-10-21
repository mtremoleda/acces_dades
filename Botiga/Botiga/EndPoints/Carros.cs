using Botiga.Repository;
using Botiga.Services;
using Botiga.Model;

namespace Botiga.EndPoints;

public static class EndpointsCarros
{
    public static void MapCarrosEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /carros
        app.MapGet("/carros", () =>
        {
            List<Carros> carros = CarrosADO.GetAll(dbConn);
            return Results.Ok(carros);
        });

        // GET /carros/{id}
        app.MapGet("/carros/{id}", (Guid id) =>
        {
            Carros carro = CarrosADO.GetById(dbConn, id)!;

            return carro is not null
                ? Results.Ok(carro)
                : Results.NotFound(new { message = $"Carro with Id {id} not found." });
        });

        // POST /carros
        app.MapPost("/carros", (CarrosRequest req) =>
        {
            Carros carro = new Carros
            {
                Id = Guid.NewGuid(),
                Nom = req.Nom
            };

            CarrosADO.Insert(dbConn, carro);

            return Results.Created($"/carros/{carro.Id}", carro);
        });
    }
}

public record CarrosRequest(string Nom);  // Estructura esperada en el POST
