using aspGestProy.Models;
using aspGestProy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.Repositories
{
    public class RolesRepository : Repository<Rol>
    {
        public Rol GetRolByNombre(string nombre)
        {
            return GetAll().FirstOrDefault(x => x.Nombre.ToLower() == nombre);
        }

        public void InsertRolVM(RolViewModel rol_VM)
        {
            Rol rol = new Rol()
            {
                Nombre = rol_VM.Nombre
            };

            Insert(rol);
        }

        public void UpdateRolVM(RolViewModel rol_VM)
        {
            var rolResult = GetById(rol_VM.IdRol);
            if (rolResult != null)
            {
                rolResult.Nombre = rol_VM.Nombre;

                Update(rolResult);
            }
        }

        public RolViewModel GetRolById(int id)
        {
            return Context.Rol.Select(x => new RolViewModel
            {
                IdRol = x.IdRol,
                Nombre = x.Nombre
            }).FirstOrDefault(x => x.IdRol == id);
        }
    }
}
