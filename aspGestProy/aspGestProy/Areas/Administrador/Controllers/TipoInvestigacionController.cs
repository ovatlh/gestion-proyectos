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
    public class TipoInvestigacionController : Controller
    {
        public IActionResult Index()
        {
            TipoInvestigacionesRepository tipoInvestigacionesRepository = new TipoInvestigacionesRepository();
            IEnumerable<Tipoinvestigacion> tipoinvestigacionesEnumerable = tipoInvestigacionesRepository.GetAll();
            return View(tipoinvestigacionesEnumerable);
        }

        //Get------------------------------------------------------------------

        public IActionResult Agregar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            TipoInvestigacionesRepository tipoInvestigacionesRepository = new TipoInvestigacionesRepository();
            var tipoinvestigacionResult = tipoInvestigacionesRepository.GetTipoInvById(id);
            return View(tipoinvestigacionResult);
        }
        public IActionResult Eliminar(int id)
        {
            TipoInvestigacionesRepository tipoInvestigacionesRepository = new TipoInvestigacionesRepository();
            var tipoinvestigacionResult = tipoInvestigacionesRepository.GetTipoInvById(id);
            return View(tipoinvestigacionResult);
        }

        //Post--------------------------------------------------------------------
        [HttpPost]
        public IActionResult Agregar(TipoInvestigacionViewModel TipoInv_VM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoInvestigacionesRepository tipoInvestigacionesRepository = new TipoInvestigacionesRepository();
                    var tipoinvestigacionResult = tipoInvestigacionesRepository.GetTipoinvestigacionByNombre(TipoInv_VM.Nombre.ToLower());

                    //Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s ]+$");
                    bool resultado = true;
                    resultado = regex.IsMatch(TipoInv_VM.Nombre);

                    if (!resultado)
                    {
                        ModelState.AddModelError("", "No se aceptan números y caracteres especiales en el nombre (Solo: a-z, A-Z).");
                        return View(TipoInv_VM);
                    }

                    Regex regexNoNumStart = new Regex(@"[0-9]| $");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = TipoInv_VM.Nombre.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con NÚMERO o con ESPACIO.");
                        return View(TipoInv_VM);
                    }

                    if (tipoinvestigacionResult == null)
                    {
                        tipoInvestigacionesRepository.InsertTipoInvestigacionVM(TipoInv_VM);

                        return RedirectToAction("Tipoinvestigacion", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe un tipo de investigación con el mismo nombre.");
                        return View(TipoInv_VM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(TipoInv_VM);
                }
            }
            else
            {
                return View(TipoInv_VM);
            }
        }
        [HttpPost]
        public IActionResult Editar(TipoInvestigacionViewModel TipoInv_VM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoInvestigacionesRepository tipoInvestigacionesRepository = new TipoInvestigacionesRepository();
                    var tipoinvestigacionResult = tipoInvestigacionesRepository.GetTipoinvestigacionByNombre(TipoInv_VM.Nombre.ToLower());

                    //Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s ]+$");
                    bool resultado = true;
                    resultado = regex.IsMatch(TipoInv_VM.Nombre);

                    if (!resultado)
                    {
                        ModelState.AddModelError("", "No se aceptan números y caracteres especiales en el nombre (Solo: a-z, A-Z).");
                        return View(TipoInv_VM);
                    }

                    Regex regexNoNumStart = new Regex(@"[0-9]| $");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = TipoInv_VM.Nombre.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con NÚMERO o con ESPACIO.");
                        return View(TipoInv_VM);
                    }

                    if (tipoinvestigacionResult == null)
                    {
                        tipoInvestigacionesRepository.UpdateTipoInvetigacionVM(TipoInv_VM);

                        return RedirectToAction("Tipoinvestigacion", "Administrador");
                    }
                    else if (tipoinvestigacionResult.IdTipoInvestigacion == TipoInv_VM.IdTipoInvestigacion)
                    {
                        tipoinvestigacionResult.Nombre = TipoInv_VM.Nombre;
                        tipoInvestigacionesRepository.Update(tipoinvestigacionResult);

                        return RedirectToAction("Tipoinvestigacion", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe este tipo de investigación.");
                        return View(TipoInv_VM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(TipoInv_VM);
                }
            }
            else
            {
                return View(TipoInv_VM);
            }
        }
        [HttpPost]
        public IActionResult Eliminar(TipoInvestigacionViewModel TipoInv_VM)
        {
            TipoInvestigacionesRepository tipoInvestigacionesRepository = new TipoInvestigacionesRepository();
            var tipoinvestigacionResult = tipoInvestigacionesRepository.GetById(TipoInv_VM.IdTipoInvestigacion);

            if (tipoinvestigacionResult != null)
            {
                tipoInvestigacionesRepository.Delete(tipoinvestigacionResult);
            }

            return RedirectToAction("Tipoinvestigacion", "Administrador");
        }
    }
}