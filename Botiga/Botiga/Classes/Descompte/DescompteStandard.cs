
using Botiga.Model;

namespace Botiga.Descomptes;
public class DescompteStandard : IDescompte
{

    public decimal CalcularDte(decimal import)
    {
        decimal decompte = import * 0.05m;
        return decompte;
        

    }

}