using LAB12.Models;
using LAB12.Requests;
using LAB12.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly Jueves18Context _context;

        public CursosController(Jueves18Context context)
        {
            _context = context;
        }

        // GET: api/cursos
        [HttpGet]
        public ActionResult GetCursos()
        {
            var cursos = _context.Cursos
                .Include(x => x.Instructor)
                .Select(x => new CursoResponse
                {
                    IdCurso = x.IdCurso,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    DuracionHoras = x.DuracionHoras,
                    NombreInstructor = x.Instructor.Nombres + " " + x.Instructor.Apellidos
                })
                .ToList();

            return Ok(cursos);
        }

        // GET: api/cursos/5
        [HttpGet("{id}")]
        public ActionResult GetCurso(int id)
        {
            var curso = _context.Cursos
                .Include(x => x.Instructor)
                .Where(x => x.IdCurso == id)
                .Select(x => new CursoDetalleResponse
                {
                    IdCurso = x.IdCurso,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio,
                    DuracionHoras = x.DuracionHoras,
                    NombreInstructor = x.Instructor.Nombres + " " + x.Instructor.Apellidos
                })
                .FirstOrDefault();

            if (curso == null)
            {
                return NotFound(new MessageResponse
                {
                    Mensaje = "Curso no encontrado"
                });
            }

            return Ok(curso);
        }

        // POST: api/cursos
        [HttpPost]
        public ActionResult PostCurso(CursoRequest request)
        {
            var instructor = _context.Instructores
                .FirstOrDefault(x => x.IdInstructor == request.IdInstructor);

            if (instructor == null)
            {
                return BadRequest(new MessageResponse
                {
                    Mensaje = "El instructor no existe"
                });
            }

            Curso curso = new Curso();

            curso.Nombre = request.Nombre;
            curso.Descripcion = request.Descripcion;
            curso.Precio = request.Precio;
            curso.DuracionHoras = request.DuracionHoras;
            curso.IdInstructor = request.IdInstructor;
            curso.Activo = true;

            _context.Cursos.Add(curso);

            _context.SaveChanges();

            return Ok(new MessageResponse
            {
                Mensaje = "Curso registrado correctamente"
            });
        }
    }
}