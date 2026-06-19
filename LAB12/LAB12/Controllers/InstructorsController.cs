using LAB12.Models;
using LAB12.Requests;
using LAB12.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LAB12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly Jueves18Context _context;

        public InstructorsController(Jueves18Context context)
        {
            _context = context;
        }

        // GET: api/instructors
        [HttpGet]
        public ActionResult GetInstructores()
        {
            var lista = _context.Instructores
                .Select(x => new InstructorResponse
                {
                    IdInstructor = x.IdInstructor,
                    NombreCompleto = x.Nombres + " " + x.Apellidos,
                    Especialidad = x.Especialidad,
                    Email = x.Email
                })
                .ToList();

            return Ok(lista);
        }

        // GET: api/instructors/{id}
        [HttpGet("{id}")]
        public ActionResult GetInstructor(int id)
        {
            var instructor = _context.Instructores
                .Where(x => x.IdInstructor == id)
                .Select(x => new InstructorResponse
                {
                    IdInstructor = x.IdInstructor,
                    NombreCompleto = x.Nombres + " " + x.Apellidos,
                    Especialidad = x.Especialidad,
                    Email = x.Email
                })
                .FirstOrDefault();

            if (instructor == null)
            {
                return NotFound(new
                {
                    mensaje = "Instructor no encontrado"
                });
            }

            return Ok(instructor);
        }

        // POST: api/instructors
        [HttpPost]
        public ActionResult PostInstructor(InstructorRequest request)
        {
            try
            {
                var instructor = new Instructor
                {
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Especialidad = request.Especialidad,
                    Email = request.Email,
                    Activo = true
                };

                _context.Instructores.Add(instructor);
                _context.SaveChanges();

                return Ok(new
                {
                    mensaje = "Instructor registrado correctamente"
                });
            }
            catch
            {
                return BadRequest(new
                {
                    mensaje = "Error al registrar instructor"
                });
            }
        }
    }
}