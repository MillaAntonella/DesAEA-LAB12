using LAB12.Models;
using LAB12.Requests;
using LAB12.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LAB12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly Jueves18Context _context;

        public EstudiantesController(Jueves18Context context)
        {
            _context = context;
        }

        // GET: api/estudiantes
        [HttpGet]
        public ActionResult GetEstudiantes()
        {
            var lista = _context.Estudiantes
                .Select(x => new EstudianteResponse
                {
                    IdEstudiante = x.IdEstudiante,
                    NombreCompleto = x.Nombres + " " + x.Apellidos,
                    Email = x.Email,
                    Telefono = x.Telefono
                })
                .ToList();

            return Ok(lista);
        }

        // GET: api/estudiantes/{id}
        [HttpGet("{id}")]
        public ActionResult GetEstudiante(int id)
        {
            var estudiante = _context.Estudiantes
                .Where(x => x.IdEstudiante == id)
                .Select(x => new EstudianteResponse
                {
                    IdEstudiante = x.IdEstudiante,
                    NombreCompleto = x.Nombres + " " + x.Apellidos,
                    Email = x.Email,
                    Telefono = x.Telefono
                })
                .FirstOrDefault();

            if (estudiante == null)
            {
                return NotFound(new
                {
                    mensaje = "Estudiante no encontrado"
                });
            }

            return Ok(estudiante);
        }

        // POST: api/estudiantes
        [HttpPost]
        public ActionResult PostEstudiante(EstudianteRequest request)
        {
            try
            {
                var estudiante = new Estudiante
                {
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Email = request.Email,
                    Telefono = request.Telefono,
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };

                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();

                return Ok(new
                {
                    mensaje = "Estudiante registrado correctamente"
                });
            }
            catch
            {
                return BadRequest(new
                {
                    mensaje = "Error al registrar estudiante"
                });
            }
        }
    }
}