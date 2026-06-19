using System.ComponentModel.DataAnnotations;

namespace LAB12.Models
{
    public class Instructor
    {
        [Key]
        public int IdInstructor { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Especialidad { get; set; }

        public string Email { get; set; }

        public bool Activo { get; set; }

        public ICollection<Curso> Cursos { get; set; }
    }
}