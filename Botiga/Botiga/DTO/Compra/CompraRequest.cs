
using Botiga.Domain.Entities;
using Botiga.DTO.Compra;

namespace Botiga.DTO.Compra;

public record CompraRequest(Guid IdClient, List<LineaProducteRequest> Productes)
{
    
    public Compra ToCompra (Guid IdClient)
    {
        return new Compra(IdClient, Productes);
    }

    
}




