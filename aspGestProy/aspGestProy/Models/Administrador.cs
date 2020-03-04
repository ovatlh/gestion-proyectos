using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public int IdUsuario { get; set; }
        public string ClaveEscolar { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public int IdCarrera { get; set; }

        public Carrera IdCarreraNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
