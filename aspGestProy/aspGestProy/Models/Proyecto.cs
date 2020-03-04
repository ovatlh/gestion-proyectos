using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Entregable = new HashSet<Entregable>();
            Proyectoalumno = new HashSet<Proyectoalumno>();
            Proyectoasesor = new HashSet<Proyectoasesor>();
        }

        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string MemoriaPdf { get; set; }
        public int Avance { get; set; }
        public sbyte AutorizadoComite { get; set; }
        public sbyte AutorizadoAsesor { get; set; }
        public sbyte AutorizadoAdministrador { get; set; }
        public int IdCategoria { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaTerminacion { get; set; }
        public DateTime FechaTentativaTerminacion { get; set; }
        public int IdArea { get; set; }
        public string ObjetivoGeneral { get; set; }
        public int IdTipoInvestigacion { get; set; }
        public int IdAsesorResponsable { get; set; }
        public string ObjetivosEspecificos { get; set; }
        public int IdLineaInvestigacion { get; set; }

        public Area IdAreaNavigation { get; set; }
        public Asesor IdAsesorResponsableNavigation { get; set; }
        public Categoria IdCategoriaNavigation { get; set; }
        public Lineainvestigacion IdLineaInvestigacionNavigation { get; set; }
        public Tipoinvestigacion IdTipoInvestigacionNavigation { get; set; }
        public ICollection<Entregable> Entregable { get; set; }
        public ICollection<Proyectoalumno> Proyectoalumno { get; set; }
        public ICollection<Proyectoasesor> Proyectoasesor { get; set; }
    }
}
