using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.ViewModels
{
    public class AreaViewModel
    {
        public int IdArea { get; set; }

        [Required(ErrorMessage = "El Área es obligatorio.")]
        [MaxLength(45, ErrorMessage = "El Área no debe de sobrepasar los 45 caracteres.")]
        public string SectorEstrategico { get; set; }
    }
}
