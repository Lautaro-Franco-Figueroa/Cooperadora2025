using Cooperadora2025.Shared.ENUM;

namespace Cooperadora2025.BD.Datos
{
    public interface IEntidadBase
    {
        EnumEstadoRegistro EstadoRegistro { get; set; }
        int Id { get; set; }
    }
}