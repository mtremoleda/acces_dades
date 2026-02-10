namespace Botiga.Model
{
    public class Carros
    {
        public Guid Id { get; set; }

        public string Nom { get; set; } = "";

        public DateOnly Data { get; set; } 
        public Guid idClient { get; set; }


    }
}