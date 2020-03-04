using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Lineainvestigacion
    {
        public Lineainvestigacion()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdLineaInvestigacion { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int IdCarrera { get; set; }
        public int? IdAsesorResponsable { get; set; }

        public Asesor IdAsesorResponsableNavigation { get; set; }
        public Carrera IdCarreraNavigation { get; set; }
        public ICollection<Proyecto> Proyecto { get; set; }
    }
}
