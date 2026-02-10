

using Botiga.Model;
using Botiga.Domain.Entities;


namespace Botiga.Infraestructure.Mappers;

public static class CompraMapper
{
    public static Compra ToDomain(CarroDeLaCompra entity)
        => new Compra(
            entity.Id,
            entity.Code,
            entity.Name,
            entity.Price
        );

    public static ProductEntity ToEntity(Product product, string? imagePath = null)
        => new ProductEntity
        {
            Id = product.Id,
            Code = product.Code,
            Name = product.Name,
            Price = product.Price,
            ImagePath = imagePath
        };
}

