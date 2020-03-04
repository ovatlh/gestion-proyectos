using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Entregable
    {
        public int IdEntregable { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdProyecto { get; set; }

        public Proyecto IdProyectoNavigation { get; set; }
    }
}
