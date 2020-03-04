using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Proyectoasesor
    {
        public int IdProyectoAsesor { get; set; }
        public int IdAsesor { get; set; }
        public int IdProyecto { get; set; }
        public string Observaciones { get; set; }

        public Asesor IdAsesorNavigation { get; set; }
        public Proyecto IdProyectoNavigation { get; set; }
    }
}
