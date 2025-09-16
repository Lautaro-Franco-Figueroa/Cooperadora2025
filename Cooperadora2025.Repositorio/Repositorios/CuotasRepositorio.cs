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
    public class CuotasRepositorio : Repositorio<Cuotas>, ICuotasRepositorio
    {
        private readonly AppDbContext context;

        public CuotasRepositorio(AppDbContext context) : base(context)
        {
          this.context = context;

        }

        public async Task<List<Cuotas?>> GetByAlumnoId(int alumnoId)
        {
            return await context.Cuotas.Where(c => c.AlumnoId == alumnoId).ToListAsync();
        }


    }
}

