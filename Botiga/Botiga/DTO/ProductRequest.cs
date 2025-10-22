
//Post
using Botiga.Model;


namespace dbdemo.DTO;

public record ProductRequest(string Nom, string Descripcio, decimal Preu, int Descompte)
{
    // Guanyem CONTROL sobre com es fa la conversió

    public Product ToProduct(Guid id)   // Conversió a model
    {
        return new Product
        {
            Id = id,
            Nom = Nom,
            Descripcio = Descripcio,
            Preu = Preu,
            Descompte = Descompte
        };
    }
}



      
