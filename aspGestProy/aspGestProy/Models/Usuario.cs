using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Administrador = new HashSet<Administrador>();
            Alumno = new HashSet<Alumno>();
            Asesor = new HashSet<Asesor>();
        }

        public int IdUsuario { get; set; }
        public string ClaveEscolar { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int TipoUsuario { get; set; }

        public ICollection<Administrador> Administrador { get; set; }
        public ICollection<Alumno> Alumno { get; set; }
        public ICollection<Asesor> Asesor { get; set; }
    }
}
