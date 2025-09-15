using Cooperadora2025.BD.Datos;
using Cooperadora2025.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperadora2025.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly AppDbContext context;

        public AlumnoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alumno>>> GetAlumnos()
        {
            var alumnos = await context.Alumnos.ToListAsync();

            if (alumnos == null)
            {
                return NotFound("No se encontraron Alumnos.");
            }
            if (alumnos.Count == 0)
            {
                return Ok("No hay Alumnos cargados.");
            }

            return Ok(alumnos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Alumno>> GetAlumnosPorId(int id)
        {
            var alumno = await context.Alumnos.FirstOrDefaultAsync(x => x.Id == id);
            if (alumno is null)
            {
                return NotFound($"No se encontro el Alumno con el id: {id}.");
            }

            return Ok(alumno);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Alumno DTO)
        {
            try
            {
                await context.Alumnos.AddAsync(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al registrar al estudiante: {ex.Message}");
            }
            
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alumno = await context.Alumnos.FirstOrDefaultAsync(x => x.Id == id);
            if (alumno is null)
            {
                return NotFound($"No se encontro el Alumno con el id: {id}.");
            }
            context.Alumnos.Remove(alumno);
            await context.SaveChangesAsync();
            return Ok($"El Alumno con el id: {id} fue eliminado.");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Alumno DTO)
        {
            if (id != DTO.Id)
            {
                return BadRequest("El id del Alumno no coincide con el id de la URL.");
            }
            var existe = await context.Alumnos.AnyAsync(x => x.Id == id);
            if (existe == false)
            {
                return NotFound($"No se encontro el Alumno con el id: {id}.");
            }
            context.Alumnos.Update(DTO);
            await context.SaveChangesAsync();
            return Ok($"El Alumno con el id: {id} fue modificado.");
        }
    }
}
