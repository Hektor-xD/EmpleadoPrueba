using EmpleadoPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpleadoPrueba.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly PruebaContext _context;
        private readonly ILogger<PruebaContext> _logger;

        public EmpleadosController(PruebaContext context, ILogger<PruebaContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        // GET: /Empleados/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleados>> GetEmpleado(int id)
        {
            var Empleado = await _context.Empleados.FindAsync(id);
            if (Empleado == null)
            {
                return NotFound();
            }
            return Empleado;
        }

        // POST: /Empleados
        [HttpPost]
        public async Task<ActionResult<Empleados>> PostEmpleado(Empleados empleado)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.EmployeeNumber }, empleado);
            //return CreatedAtAction(nameof(PostEmpleado), new { id = empleado.EmployeeNumber }, prueba);
        }

        // PUT: /Empleados/1
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEmpleado(int id, Empleados empleado)
        {
            if (id != empleado.EmployeeNumber)
            {
                return BadRequest();
            }
            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: /Empleados/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var Empleado = await _context.Empleados.FindAsync(id);
            if (Empleado == null)
            {
                return NotFound();
            }

            _context.Remove(Empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
