namespace Botiga.Model
{
    public class CarroDeLaCompra
    {
        public Guid Id { get; set; }
        public Guid IdCarro { get; set; } 
        public Guid IdProduct { get; set; }

        public decimal Preu { get; set; }
        public int Quantitat { get; set; }
    }
       
    
}
