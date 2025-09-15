using Cooperadora2025.BD.Datos;

namespace Cooperadora2025.Repositorio.Repositorios
{
    public interface IRepositorio<E> where E : class, IEntidadBase
    {
        Task<List<E>> Select();
    }
}