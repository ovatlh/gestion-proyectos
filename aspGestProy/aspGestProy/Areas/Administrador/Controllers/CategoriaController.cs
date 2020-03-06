using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using aspGestProy.Models;
using aspGestProy.Repositories;
using aspGestProy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspGestProy.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {

            CategoriasRepository categoriasRepository = new CategoriasRepository();
            IEnumerable<Categoria> categoriaEnumerable = categoriasRepository.GetAll();
            return View(categoriaEnumerable);
        }
        //Get-------------------------------------------------------------------------------------
        public IActionResult Agregar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            CategoriasRepository categoriasRepository = new CategoriasRepository();
            var categoriaResult = categoriasRepository.GetCategoriaById(id);
            return View(categoriaResult);
        }
        public IActionResult Eliminar(int id)
        {
            CategoriasRepository categoriasRepository = new CategoriasRepository();
            var categoriaResult = categoriasRepository.GetCategoriaById(id);
            return View(categoriaResult);
        }

        //Post--------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult Agregar(CategoriaViewModel categoria_VM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoriasRepository categoriasRepository = new CategoriasRepository();
                    var categoriaResult = categoriasRepository.GetCategoriaByNombre(categoria_VM.Nombre.ToLower());

                    Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    bool resultado = true;
                    resultado = regex.IsMatch(categoria_VM.Nombre);

                    if (!resultado)
                    {
                        ModelState.AddModelError("", "No se aceptan caracteres especiales (Solo: a-z, A-Z, 0-9).");
                        return View(categoria_VM);
                    }
                    Regex regexNoNumStart = new Regex(@"[0-9]$");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = categoria_VM.Nombre.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con número.");
                        return View(categoria_VM);
                    }

                    if (categoriaResult == null)
                    {
                        categoriasRepository.InsertCategoriaVM(categoria_VM);

                        return RedirectToAction("Categoria", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe una categoría con el mismo nombre.");
                        return View(categoria_VM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(categoria_VM);
                }
            }
            else
            {
                return View(categoria_VM);
            }
        }
        [HttpPost]
        public IActionResult Editar(CategoriaViewModel categoria_VM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoriasRepository categoriasRepository = new CategoriasRepository();
                    var categoriaResult = categoriasRepository.GetCategoriaByNombre(categoria_VM.Nombre.ToLower());

                    Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    bool resultado = true;
                    resultado = regex.IsMatch(categoria_VM.Nombre);

                    if (!resultado)
                    {
                        ModelState.AddModelError("", "No se aceptan caracteres especiales (Solo: a-z, A-Z, 0-9).");
                        return View(categoria_VM);
                    }
                    Regex regexNoNumStart = new Regex(@"[0-9]$");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = categoria_VM.Nombre.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con número.");
                        return View(categoria_VM);
                    }

                    if (categoriaResult == null)
                    {
                        categoriasRepository.UpdateCategoriaVM(categoria_VM);

                        return RedirectToAction("Categoria", "Administrador");
                    }
                    else if (categoriaResult.IdCategoria == categoria_VM.IdCategoria)
                    {
                        categoriaResult.Nombre = categoria_VM.Nombre;
                        categoriasRepository.Update(categoriaResult);

                        return RedirectToAction("Categoria", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe esta categoría.");
                        return View(categoria_VM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(categoria_VM);
                }
            }
            else
            {
                return View(categoria_VM);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(CategoriaViewModel categoria_VM)
        {
            CategoriasRepository categoriasRepository = new CategoriasRepository();
            var categoriaResult = categoriasRepository.GetById(categoria_VM.IdCategoria);

            if (categoriaResult != null)
            {
                categoriasRepository.Delete(categoriaResult);
            }

            return RedirectToAction("Categoria", "Administrador");
        }
    }
}
