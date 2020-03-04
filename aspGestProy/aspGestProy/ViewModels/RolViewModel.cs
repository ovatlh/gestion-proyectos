using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.ViewModels
{
    public class RolViewModel
    {
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El Rol es obligatorio.")]
        [MaxLength(45, ErrorMessage = "El Rol no debe de sobrepasar los 30 caracteres.")]
        public string Nombre { get; set; }
    }
}
