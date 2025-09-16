using Cooperadora2025.BD.Datos;
using Cooperadora2025.BD.Datos.Entidades;
using Cooperadora2025.Shared.DTO;

namespace Cooperadora2025.Repositorio.Repositorios
{
    public interface IAlumnoRepositorio: IRepositorio<Alumno>
    {
        Task<Alumno?> SelectPorDNI(int dni);
    }
}