using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.ViewModels
{
    public class CategoriaViewModel
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El Área no debe de sobrepasar los 50 caracteres.")]
        public string Nombre { get; set; }
    }
}
