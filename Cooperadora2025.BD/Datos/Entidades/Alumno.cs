using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperadora2025.BD.Datos.Entidades
{
    [Index(nameof(DNI), Name = "Alumnos_DNI_UQ", IsUnique = true)]
    public class Alumno : EntidadBase
    {

        public int DNI { get; set; }

        [Required(ErrorMessage = "El Nombre del alumno es obligatorio.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El Curso del alumno es obligatorio.")]
        public required string Curso { get; set; }

        [Required(ErrorMessage = "La Seccion del alumno es obligatorio.")]
        public required string Seccion { get; set; }

        [Required(ErrorMessage = "El Turno del alumno es obligatorio.")]
        public required string Turno { get; set; }
    }
}
