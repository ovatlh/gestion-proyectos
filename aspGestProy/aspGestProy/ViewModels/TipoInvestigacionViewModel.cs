using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.ViewModels
{
    public class TipoInvestigacionViewModel
    {
        public int IdTipoInvestigacion { get; set; }
        [Required(ErrorMessage = "El nombre del tipo de investigación es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }
    }
}
