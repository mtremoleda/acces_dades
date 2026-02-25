namespace Botiga.Model;

public class Preus
{
    public Guid idProduct { get; set; }

    public DateOnly data { get; set; }

    public decimal Preu { get; set; }
}