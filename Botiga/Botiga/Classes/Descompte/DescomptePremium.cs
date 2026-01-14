
namespace Botiga.Descomptes;
public class DescomptePremium : IDescompte
{
    
    public decimal CalcularDte(decimal import)
    {
        decimal decompte = import * 0.10m;
        return decompte;

    }

}