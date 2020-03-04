using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Tipoinvestigacion
    {
        public Tipoinvestigacion()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdTipoInvestigacion { get; set; }
        public string Nombre { get; set; }

        public ICollection<Proyecto> Proyecto { get; set; }
    }
}
