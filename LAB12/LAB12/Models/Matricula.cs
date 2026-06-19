using System.ComponentModel.DataAnnotations;

namespace LAB12.Models
{
    public class Matricula
    {
        [Key]
        public int IdMatricula { get; set; }

        public int IdEstudiante { get; set; }

        public int IdCurso { get; set; }

        public DateTime FechaMatricula { get; set; }

        public string Estado { get; set; }

        public decimal MontoTotal { get; set; }

        public Estudiante Estudiante { get; set; }

        public Curso Curso { get; set; }

        public ICollection<Pago> Pagos { get; set; }
    }
}