

using Botiga.Model;
using Botiga.Domain.Entities;


namespace Botiga.Infraestructure.Mappers;

public static class CarroDeLaCompraMapper
{

    public static CarroDeLaCompraEntity ToEntity(Guid IdCarroDeLaCompra, Guid IdCarros, LineaProducte lineaProducte, Preus preus)
        => new CarroDeLaCompraEntity
        {
            Id = IdCarroDeLaCompra,
            IdCarro = IdCarros,
            IdProduct = Guid.Parse(lineaProducte.producte.codi),
            Quantitat = lineaProducte.quantitat,
            Preu = preus.Preu
        };
}
