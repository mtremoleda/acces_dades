

using Botiga.COMMON;
using Botiga.Domain.Entities;




namespace Botiga.Domain.Validators;
public static class ProductValidator
{
    public static Result Validate(Compra compra)
    {
       
        if (compra.Productes == null || compra.Productes.Count == 0)
            return Result.Failure("La compra ha de tenir almenys un producte", "PRODUCTES_BUITS");

        foreach (var linia in compra.Productes)
        {
            if (linia.quantitat <= 0)
                return Result.Failure("La quantitat ha de ser superior a 0", "QUANTITAT_INVALIDA");

            if (linia.producte == null)
                return Result.Failure("El producte no pot ser null", "PRODUCTE_NULL");

        }

        return Result.Ok();
    }
}