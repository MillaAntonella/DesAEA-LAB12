using Microsoft.EntityFrameworkCore;

namespace LAB12.Models
{
    public class Jueves18Context : DbContext
    {
        public Jueves18Context(DbContextOptions<Jueves18Context> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Instructor> Instructores { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Matricula> Matriculas { get; set; }

        public DbSet<Pago> Pagos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(c => c.Precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Matricula>()
                .Property(m => m.MontoTotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasPrecision(10, 2);
        }
    }
}