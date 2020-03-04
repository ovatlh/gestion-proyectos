using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public ICollection<Proyecto> Proyecto { get; set; }
    }
}
