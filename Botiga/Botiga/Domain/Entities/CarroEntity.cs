using Botiga.DTO.Compras;

namespace Botiga.Domain.Entities;

public class CarroEntity
{
    public Guid Id { get; set; }

    public string Nom { get; set; } = "";

    public DateOnly Data { get; set; }
    public Guid idClient { get; set; }
}