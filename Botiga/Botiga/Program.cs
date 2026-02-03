using Microsoft.Extensions.Configuration;
using Botiga.Services;
using Botiga.EndPoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configuració
builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
DatabaseConnection dbConn = new DatabaseConnection(connectionString);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger només en desenvolupament


app.UseSwagger();
app.UseSwaggerUI();


// Redirecció a Swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Endpoints
app.MapProductEndpoints(dbConn);
app.MapCarrosEndpoints(dbConn);
app.MapFamiliaEndpoints(dbConn);
app.MapCarroDeLaCompraEndpoints(dbConn);
app.MapCompraEndpoints(dbConn);

app.Run();
