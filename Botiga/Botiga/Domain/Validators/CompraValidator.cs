

using Botiga.COMMON;
using Botiga.Domain.Entities;




namespace Botiga.Domain.Validators;
public static class CompraValidator
{
    public static Result Validate(Compra compra)
    {

        DateOnly avui = DateOnly.FromDateTime(DateTime.Now);
        if (compra.data > avui)
            return Result.Failure("La data de la compra no pot ser futura", "DATA_FUTURA");

        if ((avui.DayNumber - compra.data.DayNumber) > 10)
            return Result.Failure("La data de la compra no pot ser de més de 10 dies enrere", "DATA_MASSA_ANTERIOR");

    

        return Result.Ok();
    }
}