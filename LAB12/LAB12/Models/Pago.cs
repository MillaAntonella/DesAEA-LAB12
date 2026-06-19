using System.ComponentModel.DataAnnotations;

namespace LAB12.Models
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }

        public int IdMatricula { get; set; }

        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public string MetodoPago { get; set; }

        public string EstadoPago { get; set; }

        public Matricula Matricula { get; set; }
    }
}