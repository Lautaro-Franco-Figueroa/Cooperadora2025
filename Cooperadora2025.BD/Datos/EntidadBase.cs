using Cooperadora2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperadora2025.BD.Datos
{
    public class EntidadBase : IEntidadBase
    {
        public int Id { get; set; }
        public EnumEstadoRegistro EstadoRegistro { get; set; } = EnumEstadoRegistro.Activo;
    }
}
