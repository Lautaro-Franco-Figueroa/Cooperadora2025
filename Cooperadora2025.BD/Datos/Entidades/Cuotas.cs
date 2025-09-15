using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperadora2025.BD.Datos.Entidades
{
    public class Cuotas : EntidadBase
    {

        public int AlumnoId { get; set; }
        public Alumno? Alumno { get; set; }

        [Required(ErrorMessage = "El Mes de la cuota es obligatorio.")]
        public required string Mes { get; set; }

        public int? Monto { get; set; }

        public int? Otro { get; set; }

        public DateTime? Fecha_Pago { get; set; }

        public string? Descripcion { get; set; }
    }
}
