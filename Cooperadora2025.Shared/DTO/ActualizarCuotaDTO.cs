using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperadora2025.Shared.DTO
{
    public class ActualizarCuotaDTO
    {
        public int DNI { get; set; }   
        public string? Mes { get; set; }    
        public int Monto { get; set; }   
        public int Otro { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public string? Descripcion { get; set; }
    }
}
