using LAB12.Models;
using LAB12.Requests;
using LAB12.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculasController : ControllerBase
    {
        private readonly Jueves18Context _context;

        public MatriculasController(Jueves18Context context)
        {
            _context = context;
        }

        // GET: api/matriculas
        [HttpGet]
        public ActionResult GetMatriculas()
        {
            var lista = _context.Matriculas
                .Include(x => x.Estudiante)
                .Include(x => x.Curso)
                .Select(x => new
                {
                    x.IdMatricula,
                    Estudiante = x.Estudiante.Nombres + " " + x.Estudiante.Apellidos,
                    Curso = x.Curso.Nombre,
                    x.FechaMatricula,
                    x.Estado,
                    x.MontoTotal
                })
                .ToList();

            return Ok(lista);
        }

        // GET: api/matriculas/{id}
        [HttpGet("{id}")]
        public ActionResult GetMatricula(int id)
        {
            var matricula = _context.Matriculas
                .Include(x => x.Estudiante)
                .Include(x => x.Curso)
                .Where(x => x.IdMatricula == id)
                .Select(x => new
                {
                    x.IdMatricula,
                    Estudiante = x.Estudiante.Nombres + " " + x.Estudiante.Apellidos,
                    Curso = x.Curso.Nombre,
                    x.FechaMatricula,
                    x.Estado,
                    x.MontoTotal
                })
                .FirstOrDefault();

            if (matricula == null)
            {
                return NotFound(new MessageResponse
                {
                    Mensaje = "Matrícula no encontrada"
                });
            }

            return Ok(matricula);
        }

        // POST: api/matriculas
        [HttpPost]
        public ActionResult PostMatricula(MatriculaRequest request)
        {
            var estudiante = _context.Estudiantes
                .FirstOrDefault(x => x.IdEstudiante == request.IdEstudiante);

            var curso = _context.Cursos
                .FirstOrDefault(x => x.IdCurso == request.IdCurso);

            if (estudiante == null || curso == null)
            {
                return BadRequest(new MessageResponse
                {
                    Mensaje = "Estudiante o curso no existen"
                });
            }

            var matricula = new Matricula
            {
                IdEstudiante = request.IdEstudiante,
                IdCurso = request.IdCurso,
                FechaMatricula = DateTime.Now,
                Estado = "ACTIVO",
                MontoTotal = curso.Precio
            };

            _context.Matriculas.Add(matricula);
            _context.SaveChanges();

            return Ok(new MessageResponse
            {
                Mensaje = "Matrícula registrada correctamente"
            });
        }
    }
}