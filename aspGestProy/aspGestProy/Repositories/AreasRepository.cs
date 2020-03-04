using aspGestProy.Models;
using aspGestProy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.Repositories
{
    public class AreasRepository : Repository<Area>
    {
        public Area GetAreaByNombre(string nombre)
        {
            return GetAll().FirstOrDefault(x => x.SectorEstrategico.ToLower() == nombre);
        }

        public void InsertAreaVM(AreaViewModel area_VM)
        {
            Area area = new Area()
            {
                SectorEstrategico = area_VM.SectorEstrategico
            };

            Insert(area);
        }

        public void UpdateAreaVM(AreaViewModel area_VM)
        {
            var areaResult = GetById(area_VM.IdArea);
            if (areaResult != null)
            {
                areaResult.SectorEstrategico = area_VM.SectorEstrategico;

                Update(areaResult);
            }
        }

        public AreaViewModel GetAreaById(int id)
        {
            return Context.Area.Select(x => new AreaViewModel
            {
                IdArea = x.IdArea,
                SectorEstrategico = x.SectorEstrategico
            }).FirstOrDefault(x => x.IdArea == id);
        }
    }
}
