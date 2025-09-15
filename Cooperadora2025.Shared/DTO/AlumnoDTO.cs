using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperadora2025.Shared.DTO
{
    public class AlumnoDTO
    {
        public int DNI { get; set; }

        [Required(ErrorMessage = "El Nombre del alumno es obligatorio.")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El Curso del alumno es obligatorio.")]
        public string Curso { get; set; } = "";

        [Required(ErrorMessage = "La Seccion del alumno es obligatorio.")]
        public string Seccion { get; set; } = "";

        [Required(ErrorMessage = "El Turno del alumno es obligatorio.")]
        public string Turno { get; set; } = "";
    }
}
