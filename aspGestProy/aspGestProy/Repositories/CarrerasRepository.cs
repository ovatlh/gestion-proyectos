using aspGestProy.Models;
using aspGestProy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.Repositories
{
    public class CarrerasRepository : Repository<Carrera>
    {
        public Carrera GetCarreraByNombre(string nombre)
        {
           return GetAll().FirstOrDefault(x => x.Nombre.ToLower() == nombre);

        }
        public Carrera GetCarreraByClave(string clave)
        {
            return GetAll().FirstOrDefault(x => x.Clave == clave);

        }
        public Carrera GetCarreraByClaveNombre(string clave, string nombre)
        {
            return GetAll().FirstOrDefault(x => x.Clave == clave && x.Nombre.ToLower()==nombre);

        }



        public void InsertCarreraVM (CarreraViewModel carrera_VM)
        {
            Carrera carrera = new Carrera()
            {
                Nombre = carrera_VM.Nombre,
                Clave = carrera_VM.Clave.ToUpper()
            };
            Insert(carrera);
        }
        public void UpdateCarreraVM(CarreraViewModel carrera_VM)
        {
            var carreraResult = GetById(carrera_VM.IdCarrera);
            if (carreraResult != null)
            {
                carreraResult.Clave = carrera_VM.Clave.ToUpper();
                carreraResult.Nombre = carrera_VM.Nombre;
                Update(carreraResult);
            }      
        }
        public CarreraViewModel GetCarreraById(int id)
        {
            return Context.Carrera.Select(x => new CarreraViewModel
            {
                IdCarrera =x.IdCarrera,
                Clave=x.Clave,
                Nombre=x.Nombre
            }).FirstOrDefault(x => x.IdCarrera==id);
        }
    }
}
