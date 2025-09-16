using Cooperadora2025.BD.Datos;
using Cooperadora2025.BD.Datos.Entidades;
using Cooperadora2025.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cooperadora2025.Shared.DTO;

namespace Cooperadora2025.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<Alumno> repositorio;
        private readonly IAlumnoRepositorio alumnoRepositorio;

        public AlumnoController(AppDbContext context,
                                IRepositorio<Alumno> repositorio,
                                IAlumnoRepositorio alumnoRepositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
            this.alumnoRepositorio = alumnoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alumno>>> GetAlumnos()
        {
            
            var alumnos = await repositorio.Select();

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
        /*
         * [HttpGet("datosalumnos")]
        public async Task<ActionResult<List<AlumnoDatosDTO>>> DatosAlumnos()
        {

            var alumnos = await repositorio.SelectDatosAlumnos();

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
        */
        
        
        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<Alumno>> GetPorId(int id)
        //{
        //    var entidad = await repositorio.SelectPorId(id);
        //    if (entidad is null) 
        //    {
        //        return NotFound($"No se encontro el Alumno con el id: {id}.");
        //}
        //
        //  return Ok(entidad);
        //}

        [HttpGet("{dni:int}")]
        public async Task<ActionResult<Alumno>> GetPorDNI(int dni)
        {
            var entidad = await alumnoRepositorio.SelectPorDNI(dni);
            if (entidad is null)
            {
                return NotFound($"No se encontro el Alumno con el dni: {dni}.");
            }

            return Ok(entidad);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(AlumnoDTO DTO)
        {
            try
            {
                Alumno entidad = new()
                {
                    DNI = DTO.DNI,
                    Nombre = DTO.Nombre,
                    Curso = DTO.Curso,
                    Seccion = DTO.Seccion,
                    Turno = DTO.Turno
                };
                await repositorio.Insert(entidad);
                await context.SaveChangesAsync();
                return Ok(entidad.Id);
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
            var resultado = await repositorio.Update(id, DTO);
            if (resultado == false)
            {
                return BadRequest("No se pudo modificar el Alumno.");
            }
            return Ok($"El Alumno con el id: {id} fue modificado.");
        }
    }
}
