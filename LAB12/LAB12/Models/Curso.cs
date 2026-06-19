using System.ComponentModel.DataAnnotations;

namespace LAB12.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int DuracionHoras { get; set; }

        public int IdInstructor { get; set; }

        public bool Activo { get; set; }

        public Instructor Instructor { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}