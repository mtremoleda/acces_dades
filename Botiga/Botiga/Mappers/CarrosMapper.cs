using Botiga.Domain.Entities;

using Botiga.Model;

namespace Botiga.Infraestructure.Mappers;

public static class CarrosMapper
{
    public static CarroEntity ToEntity(Guid IdCarros, Compra compra)
        => new CarroEntity
        {
            Id = IdCarros,
            Nom = IdCarros.ToString(),
            Data = compra.data,
            idClient = Guid.Parse(compra.client.codi)
        };
}