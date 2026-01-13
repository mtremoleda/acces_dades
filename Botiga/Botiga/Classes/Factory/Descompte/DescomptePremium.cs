namespace Botiga.Descomptes;

public class DescomptePremiumFactory : IDescompteFactory
{
    public IDescompte CreateDescompte()
    {
        return new DescomptePremium();
    }

}