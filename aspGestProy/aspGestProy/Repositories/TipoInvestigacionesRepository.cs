using aspGestProy.Models;
using aspGestProy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.Repositories
{
    public class TipoInvestigacionesRepository : Repository<Tipoinvestigacion>
    {
        public Tipoinvestigacion GetTipoinvestigacionByNombre(string nombre)
        {
            return GetAll().FirstOrDefault(x => x.Nombre.ToLower() == nombre);
        }

        public void InsertTipoInvestigacionVM(TipoInvestigacionViewModel tipoInv_Vm)
        {
            Tipoinvestigacion tInv = new Tipoinvestigacion()
            {
                Nombre = tipoInv_Vm.Nombre
            };
            Insert(tInv);            
        }

        public void UpdateTipoInvetigacionVM(TipoInvestigacionViewModel tipoInv_VM)
        {
            var TipoInvResult = GetById(tipoInv_VM.IdTipoInvestigacion);
            if (TipoInvResult != null)
            {
                TipoInvResult.Nombre = tipoInv_VM.Nombre;

                Update(TipoInvResult);
            }
        }

        public TipoInvestigacionViewModel GetTipoInvById(int id)
        {
            return Context.Tipoinvestigacion.Select(x => new TipoInvestigacionViewModel
            {
                IdTipoInvestigacion=x.IdTipoInvestigacion,
                Nombre=x.Nombre
            }).FirstOrDefault(x => x.IdTipoInvestigacion == id);
        }
    }
}
