
using Botiga.Domain.Entities;

namespace Botiga.DTO.Compras;

public record LineaProducteRequest(Guid IdProducte, int quantitat)
{

      public LineaProducte ToLineaProducte()
    {
        
        Producte producte = new Producte();
        producte.codi = IdProducte.ToString();


        LineaProducte linea = new LineaProducte();

        linea.quantitat = quantitat;
        linea.producte = producte;

        return linea;

    }


}




