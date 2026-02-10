using Microsoft.AspNetCore.Http.HttpResults;

namespace Botiga.Model
{
    public class Familia
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Descripcio { get; set; } = "";
        
    }
}
