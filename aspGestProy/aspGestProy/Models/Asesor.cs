using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Asesor
    {
        public Asesor()
        {
            Lineainvestigacion = new HashSet<Lineainvestigacion>();
            Proyecto = new HashSet<Proyecto>();
            Proyectoasesor = new HashSet<Proyectoasesor>();
        }

        public int IdAsesor { get; set; }
        public int IdUsuario { get; set; }
        public string ClaveEscolar { get; set; }
        public string Cvu { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int IdCarrera { get; set; }
        public string Email { get; set; }
        public sbyte Genero { get; set; }

        public Carrera IdCarreraNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Lineainvestigacion> Lineainvestigacion { get; set; }
        public ICollection<Proyecto> Proyecto { get; set; }
        public ICollection<Proyectoasesor> Proyectoasesor { get; set; }
    }
}
