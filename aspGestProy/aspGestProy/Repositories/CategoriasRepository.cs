using aspGestProy.Models;
using aspGestProy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspGestProy.Repositories
{
    public class CategoriasRepository : Repository<Categoria>
    {
        public Categoria GetCategoriaByNombre(string nombre)
        {
            return GetAll().FirstOrDefault(x => x.Nombre.ToLower() == nombre);
        }

        public void InsertCategoriaVM(CategoriaViewModel categoria_VM)
        {
            Categoria categoria = new Categoria
            {
                Nombre = categoria_VM.Nombre
            };
            Insert(categoria);
        }

        public void UpdateCategoriaVM(CategoriaViewModel categoria_VM)
        {
            var categoriaResult = GetById(categoria_VM.IdCategoria);
            if (categoriaResult != null)
            {
                categoriaResult.Nombre = categoria_VM.Nombre;

                Update(categoriaResult);
            }
        }

        public CategoriaViewModel GetCategoriaById(int id)
        {
            return Context.Categoria.Select(x => new CategoriaViewModel
            {
                IdCategoria = x.IdCategoria,
                Nombre = x.Nombre
            }).FirstOrDefault(x => x.IdCategoria == id);
        }
    }
}
