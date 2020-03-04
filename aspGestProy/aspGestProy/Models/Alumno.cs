using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Proyectoalumno = new HashSet<Proyectoalumno>();
        }

        public int IdAlumno { get; set; }
        public int IdUsuario { get; set; }
        public string ClaveEscolar { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Genero { get; set; }
        public int Semestre { get; set; }
        public int IdCarrera { get; set; }
        public string Email { get; set; }

        public Carrera IdCarreraNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Proyectoalumno> Proyectoalumno { get; set; }
    }
}
