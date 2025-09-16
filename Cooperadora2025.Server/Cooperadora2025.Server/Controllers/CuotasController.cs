using Cooperadora2025.BD.Datos;
using Cooperadora2025.BD.Datos.Entidades;
using Cooperadora2025.Repositorio.Repositorios;
using Cooperadora2025.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperadora2025.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuotasController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly ICuotasRepositorio repositorio;
        private readonly IAlumnoRepositorio alumnoRepositorio;

        public CuotasController(AppDbContext context, IAlumnoRepositorio alumnoRepositorio, ICuotasRepositorio repositorio)
        {
            this.context = context;
            this.alumnoRepositorio = alumnoRepositorio;
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cuotas>>> GetCuotas()
        {
            var cuotas = await repositorio.Select();
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Cuotas>>> GetCuotasPorDni(int id)
        {
            var entidad = await repositorio.GetByAlumnoId(id);

            if (entidad is null)
            {
                return NotFound($"No se encontro el Alumno con el id: {id}.");
            }

            return Ok(entidad);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCuota([FromBody] ActualizarCuotaDTO dto)
        {
            var alumno = await context.Alumnos
                .FirstOrDefaultAsync(a => a.DNI == dto.DNI);

            if (alumno == null)
                return NotFound("No se encontró un alumno con ese DNI.");

            var cuota = await context.Cuotas
                .FirstOrDefaultAsync(c => c.AlumnoId == alumno.Id && c.Mes == dto.Mes);

            if (cuota == null)
                return NotFound("No se encontró una cuota para ese mes.");

            cuota.Monto = dto.Monto;
            cuota.Otro = dto.Otro;
            cuota.Fecha_Pago = dto.Fecha_Pago;
            cuota.Descripcion = dto.Descripcion;

            await context.SaveChangesAsync();

            return Ok("Cuota actualizada correctamente.");
        }
    }
}
