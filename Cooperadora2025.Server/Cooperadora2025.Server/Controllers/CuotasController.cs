using Cooperadora2025.BD.Datos;
using Cooperadora2025.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperadora2025.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuotasController : ControllerBase
    {
        private readonly AppDbContext context;

        public CuotasController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cuotas>>> GetCuotas()
        {
            var cuotas = await context.Cuotas.ToListAsync();
            if (cuotas == null)
            {
                return NotFound("No se encontraron cuotas.");
            }
            if (cuotas.Count == 0)
            {
                return Ok("No hay cuotas cargadas.");
            }

            return Ok(cuotas);
        }
    }
}
