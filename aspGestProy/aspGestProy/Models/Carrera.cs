using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Administrador = new HashSet<Administrador>();
            Alumno = new HashSet<Alumno>();
            Asesor = new HashSet<Asesor>();
            Lineainvestigacion = new HashSet<Lineainvestigacion>();
        }

        public int IdCarrera { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }

        public ICollection<Administrador> Administrador { get; set; }
        public ICollection<Alumno> Alumno { get; set; }
        public ICollection<Asesor> Asesor { get; set; }
        public ICollection<Lineainvestigacion> Lineainvestigacion { get; set; }
    }
}
