namespace Botiga.Descomptes;

public class DescompteEstandarFactory : IDescompteFactory
{
     public IDescompte CreateDescompte()
    {
        return new DescompteStandard();
    }

}