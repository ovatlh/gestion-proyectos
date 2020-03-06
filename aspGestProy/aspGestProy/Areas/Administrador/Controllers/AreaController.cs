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
    public class AreaController : Controller
    {
        public IActionResult Index()
        {
            AreasRepository areasRepository = new AreasRepository();
            IEnumerable<Area> areasIEnumerable = areasRepository.GetAll();
            return View(areasIEnumerable);
        }

        //GET --------------------------------------------------------------------------------------
        public IActionResult Agregar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            AreasRepository areasRepository = new AreasRepository();
            var areaResult = areasRepository.GetAreaById(id);
            return View(areaResult);
        }

        public IActionResult Eliminar(int id)
        {
            AreasRepository areasRepository = new AreasRepository();
            //var areaResult = areasRepository.GetById(id);
            var areaResult = areasRepository.GetAreaById(id);
            return View(areaResult);
        }

        //POST --------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult Agregar(AreaViewModel areaVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AreasRepository areasRepository = new AreasRepository();
                    var areaResult = areasRepository.GetAreaByNombre(areaVM.SectorEstrategico.ToLower());
                    
                    Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    bool resultado = true;
                    resultado = regex.IsMatch(areaVM.SectorEstrategico);

                    if (!resultado)
                    {
                        ModelState.AddModelError("", "No se aceptan caracteres especiales (Solo: a-z, A-Z, 0-9).");
                        return View(areaVM);
                    }

                    Regex regexNoNumStart = new Regex(@"[0-9]$");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = areaVM.SectorEstrategico.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con número.");
                        return View(areaVM);
                    }

                    if (areaResult == null)
                    {
                        areasRepository.InsertAreaVM(areaVM);

                        return RedirectToAction("Area", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe un Area con el mismo nombre.");
                        return View(areaVM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(areaVM);
                }
            }
            else
            {
                return View(areaVM);
            }
        }

        [HttpPost]
        public IActionResult Editar(AreaViewModel areaVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AreasRepository areasRepository = new AreasRepository();
                    var areaResult = areasRepository.GetAreaByNombre(areaVM.SectorEstrategico.ToLower());

                    Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    bool resultado = true;
                    resultado = regex.IsMatch(areaVM.SectorEstrategico);

                    if (!resultado)
                    {
                        ModelState.AddModelError("", "No se aceptan caracteres especiales (Solo: a-z, A-Z, 0-9).");
                        return View(areaVM);
                    }

                    Regex regexNoNumStart = new Regex(@"[0-9]$");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = areaVM.SectorEstrategico.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con número.");
                        return View(areaVM);
                    }

                    if (areaResult == null)
                    {
                        areasRepository.UpdateAreaVM(areaVM);

                        return RedirectToAction("Area", "Administrador");
                    }
                    else if(areaResult.IdArea == areaVM.IdArea)
                    {
                        areaResult.SectorEstrategico = areaVM.SectorEstrategico;
                        areasRepository.Update(areaResult);

                        return RedirectToAction("Area", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe este sector estrategico.");
                        return View(areaVM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(areaVM);
                }
            }
            else
            {
                return View(areaVM);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(AreaViewModel areaVM)
        {
            AreasRepository areasRepository = new AreasRepository();
            var areaResult = areasRepository.GetById(areaVM.IdArea);

            if (areaResult != null)
            {
                areasRepository.Delete(areaResult);
            }

            return RedirectToAction("Area", "Administrador");
        }
    }
}