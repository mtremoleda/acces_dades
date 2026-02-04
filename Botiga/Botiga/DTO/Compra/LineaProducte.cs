
using Botiga.Domain.Entities;

namespace Botiga.DTO.Compras;

public record LineaProducteRequest(Guid Id, int quantitat)
{

      public LineaProducte ToProducte()
    {
        
        Producte producte = new Producte();
        LineaProducte linea = new LineaProducte();

        linea.quantitat = quantitat;
        linea.producte = producte;

        return linea;

    }


}




