using System;
using System.Collections.Generic;

namespace aspGestProy.Models
{
    public partial class Area
    {
        public Area()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        public int IdArea { get; set; }
        public string SectorEstrategico { get; set; }

        public ICollection<Proyecto> Proyecto { get; set; }
    }
}
