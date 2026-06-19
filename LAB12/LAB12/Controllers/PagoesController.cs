using LAB12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoesController : ControllerBase
    {
        private readonly Jueves18Context _context;

        public PagoesController(Jueves18Context context)
        {
            _context = context;
        }

        // GET: api/Pagoes
        [HttpGet]
        public ActionResult GetPagos()
        {
            var pagos = _context.Pagos.ToList();
            return Ok(pagos);
        }

        // GET: api/Pagoes/5
        [HttpGet("{id}")]
        public ActionResult GetPago(int id)
        {
            var pago = _context.Pagos.FirstOrDefault(x => x.IdPago == id);

            if (pago == null)
            {
                return NotFound();
            }

            return Ok(pago);
        }

        // POST: api/Pagoes
        [HttpPost]
        public ActionResult PostPago(Pago pago)
        {
            _context.Pagos.Add(pago);
            _context.SaveChanges();

            return Ok(new
            {
                mensaje = "Pago registrado correctamente"
            });
        }

        // DELETE: api/Pagoes/5
        [HttpDelete("{id}")]
        public ActionResult DeletePago(int id)
        {
            var pago = _context.Pagos.FirstOrDefault(x => x.IdPago == id);

            if (pago == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pago);
            _context.SaveChanges();

            return Ok(new
            {
                mensaje = "Pago eliminado correctamente"
            });
        }
    }
}