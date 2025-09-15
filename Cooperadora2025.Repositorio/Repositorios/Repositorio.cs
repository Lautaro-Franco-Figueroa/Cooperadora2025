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

        public async Task<E?> SelectPorId(int id)
        {
            return await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err) { throw err; }
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = await context.Set<E>().AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }
            var existe = await Existe(id);
            if (!existe)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception err) { throw err; }
        }

        public async Task<List<AlumnoDatosDTO>> SelectDatosAlumnos()
        {
            var alumnos = await context.Alumnos
                .Select(a => new AlumnoDatosDTO
                {
                    DNI = a.DNI,
                    Nombre = a.Nombre,
                    Curso = a.Curso,
                    Seccion = a.Seccion,
                    Turno = a.Turno
                })
                .ToListAsync();
            return alumnos;
        }
    }
}
