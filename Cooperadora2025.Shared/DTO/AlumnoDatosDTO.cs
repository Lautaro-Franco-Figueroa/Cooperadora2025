using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperadora2025.Shared.DTO
{
    public class AlumnoDatosDTO
    {
        public int DNI { get; set; }
        public string Nombre { get; set; } = "";
        public string Curso { get; set; } = "";
        public string Seccion { get; set; } = "";
        public string Turno { get; set; } = "";
    }
}
