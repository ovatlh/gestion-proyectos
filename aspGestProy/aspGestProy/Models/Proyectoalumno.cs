using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Proyectoalumno
    {
        public int IdProyectoAlumno { get; set; }
        public int IdAlumno { get; set; }
        public int IdProyecto { get; set; }
        public int IdRol { get; set; }

        public Alumno IdAlumnoNavigation { get; set; }
        public Proyecto IdProyectoNavigation { get; set; }
        public Rol IdRolNavigation { get; set; }
    }
}
