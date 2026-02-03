using Botiga.DTO.Compra;

namespace Botiga.Domain.Entities;

public class Compra
{
    
    public  Guid Id { get; set; }
    public Guid IdClient { get; set; } 
    public List <LineaProducteRequest> Productes { get; set; }
    

    public Compra(Guid IdClient, List<LineaProducteRequest> productes)
    {
        
        Id = Guid.NewGuid();
        IdClient = IdClient;
        Productes = productes;
    }

}