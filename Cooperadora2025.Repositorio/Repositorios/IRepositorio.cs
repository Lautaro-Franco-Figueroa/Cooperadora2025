using Cooperadora2025.BD.Datos;
using Cooperadora2025.Shared.DTO;

namespace Cooperadora2025.Repositorio.Repositorios
{
    public interface IRepositorio<E> where E : class, IEntidadBase
    {
        Task<bool> Existe(int id);
        Task<int> Insert(E entidad);
        Task<List<E>> Select();
        Task<List<AlumnoDatosDTO>> SelectDatosAlumnos();
        Task<E?> SelectPorId(int id);
        Task<bool> Update(int id, E DTO);
    }
}