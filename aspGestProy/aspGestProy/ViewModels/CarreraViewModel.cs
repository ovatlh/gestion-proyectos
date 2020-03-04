using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.ViewModels
{
    public class CarreraViewModel
    {
        
        public int IdCarrera { get; set; }
        [Required (ErrorMessage ="La clave es obligatoria")]
        [MaxLength (2,ErrorMessage ="La clave no acepta más de 2 caracteres")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El nombre de la carrera es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }
    }
}
