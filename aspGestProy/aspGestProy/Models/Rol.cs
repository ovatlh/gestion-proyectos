using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Proyectoalumno = new HashSet<Proyectoalumno>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }

        public ICollection<Proyectoalumno> Proyectoalumno { get; set; }
    }
}
