using Cooperadora2025.BD.Datos;
using Cooperadora2025.BD.Datos.Entidades;
using Cooperadora2025.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperadora2025.Repositorio.Repositorios
{
    public class AlumnoRepositorio : Repositorio<Alumno>, IAlumnoRepositorio
    {
        private readonly AppDbContext context;

        public AlumnoRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Alumno?> SelectPorDNI(int dni)
        {
            return await context.Set<Alumno>().FirstOrDefaultAsync(x => x.DNI == dni);
        }
    }
}
