
using Botiga.Domain.Entities;

namespace Botiga.DTO.Compras;

public record CompraRequest(Guid IdClient, DateOnly Data, List<LineaProducteRequest> Productes)
{
    
    public Compra ToCompra()
    {
        

        Client client = new Client();
        client.codi = IdClient.ToString();

        Compra compraDomain = new Compra();
        compraDomain.client = client;

        compraDomain.data = Data;

        List<LineaProducte> ProductesDomain = new List<LineaProducte>();

        foreach (LineaProducteRequest producte in Productes)
        {
            ProductesDomain.Add(producte.ToLineaProducte());   
        }
        compraDomain.Productes = ProductesDomain;

        return compraDomain;
    }

    
}




