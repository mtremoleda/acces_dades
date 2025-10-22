
//Get
using Botiga.Model;


namespace Botiga.DTO;

public record ProductResponse(Guid Id, string Nom, string Descripcio, decimal Preu, int Descompte)
{
    // Guanyem CONTROL sobre com es fa la conversió

    public static ProductResponse FromProduct(Product product)   // Conversió de model a response
    {
        return new ProductResponse(product.Id, product.Nom, product.Descripcio, product.Preu, product.Descompte);
    }
}





