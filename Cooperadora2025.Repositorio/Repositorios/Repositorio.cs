using Cooperadora2025.BD.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperadora2025.Repositorio.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntidadBase
    {
        private readonly AppDbContext context;

        public Repositorio(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<E>> Select()
        {
            //var alumnos = await context.Alumnos.ToListAsync();
            return await context.Set<E>().ToListAsync();
        }
    }
}
