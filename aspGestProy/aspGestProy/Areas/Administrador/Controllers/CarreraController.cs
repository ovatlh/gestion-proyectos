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
    public class CarreraController : Controller
    {

        public IActionResult Index()
        {
            CarrerasRepository carrerasRepository = new CarrerasRepository();
            IEnumerable<Carrera> carrerasIEnumerable = carrerasRepository.GetAll();
            return View(carrerasIEnumerable);
        }
        //GET --------------------------------------------------------------------------------------
        public IActionResult Agregar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            CarrerasRepository carrerasRepository = new CarrerasRepository();
            var carreraResult = carrerasRepository.GetCarreraById(id);
            return View(carreraResult);
        }

        public IActionResult Eliminar(int id)
        {
            CarrerasRepository carrerasRepository = new CarrerasRepository();
            var carreraResult = carrerasRepository.GetCarreraById(id);
            return View(carreraResult);
        }
        //POST --------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult Agregar(CarreraViewModel carreraVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CarrerasRepository carreraRepository = new CarrerasRepository();
                    var carreraResultNombre = carreraRepository.GetCarreraByNombre(carreraVM.Nombre.ToLower());
                    var carreraResultClave = carreraRepository.GetCarreraByClave(carreraVM.Clave);
                    var carreraResult = carreraRepository.GetCarreraByClaveNombre(carreraVM.Clave, carreraVM.Nombre.ToLower());

                    //Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    Regex regexClave = new Regex(@"^[a-zA-Z]+$");
                    Regex regexNombre = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s  ]+$");
                    bool resultadoClave = true;
                    resultadoClave = regexClave.IsMatch(carreraVM.Clave);
                    bool resultadoNombre = true;
                    resultadoNombre = regexNombre.IsMatch(carreraVM.Nombre);

                    if (!resultadoClave)
                    {
                        ModelState.AddModelError("", "La clave de la carrera solo acepta letras. (Máximo 2, verifique espacios)");
                        return View(carreraVM);
                    }
                    if (!resultadoNombre)
                    {
                        ModelState.AddModelError("", "No se aceptan números y caracteres especiales en el nombre (Solo: a-z, A-Z).");
                        return View(carreraVM);
                    }

                    //if (!resultadoClave || !resultadoNombre)
                    //{
                    //    ModelState.AddModelError("", "No se aceptan caracteres especiales (Solo: a-z, A-Z, 0-9).");
                    //    return View(carreraVM);
                    //}

                    Regex regexNoNumStart = new Regex(@"[0-9]| $");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = carreraVM.Nombre.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con NÚMERO o con ESPACIO.");
                        return View(carreraVM);
                    }

                    if (carreraResult== null)
                    {
                        if (carreraResultNombre != null)
                        {
                            ModelState.AddModelError("", "Ya existe una carrera con el mismo nombre ");
                            return View(carreraVM);
                        }
                        if (carreraResultClave != null)
                        {
                            ModelState.AddModelError("", "Ya existe una carrera con la misma clave");
                            return View(carreraVM);
                        }

                        carreraRepository.InsertCarreraVM(carreraVM);

                        return RedirectToAction("Carrera", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe esta carrera");
                        return View(carreraVM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(carreraVM);
                }
            }
            else
            {
                return View(carreraVM);
            }
        }

        [HttpPost]
        public IActionResult Editar(CarreraViewModel carreraVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CarrerasRepository carreraRepository = new CarrerasRepository();
                    var carreraResultNombre = carreraRepository.GetCarreraByNombre(carreraVM.Nombre.ToLower());
                    var carreraResultClave = carreraRepository.GetCarreraByClave(carreraVM.Clave);
                    var carreraResult = carreraRepository.GetCarreraByClaveNombre(carreraVM.Clave, carreraVM.Nombre.ToLower());

                    //Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    Regex regexClave = new Regex(@"^[a-zA-Z]+$");
                    Regex regexNombre = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s  ]+$");
                    bool resultadoClave = true;
                    resultadoClave = regexClave.IsMatch(carreraVM.Clave);
                    bool resultadoNombre = true;
                    resultadoNombre = regexNombre.IsMatch(carreraVM.Nombre);

                    if (!resultadoClave)
                    {
                        ModelState.AddModelError("", "La clave de la carrera solo acepta letras. (Máximo 2, verifique espacios)");
                        return View(carreraVM);
                    }
                    if (!resultadoNombre)
                    {
                        ModelState.AddModelError("", "No se aceptan números y caracteres especiales en el nombre (Solo: a-z, A-Z).");
                        return View(carreraVM);
                    }

                    //if (!resultadoClave || !resultadoNombre)
                    //{
                    //    ModelState.AddModelError("", "No se aceptan caracteres especiales (Solo: a-z, A-Z, 0-9).");
                    //    return View(carreraVM);
                    //}

                    Regex regexNoNumStart = new Regex(@"[0-9]| $");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = carreraVM.Nombre.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con NÚMERO o con ESPACIO.");
                        return View(carreraVM);
                    }

                    if (carreraResult == null)
                    {

                        if (carreraResultNombre != null)
                        {
                            if (carreraVM.IdCarrera != carreraResultNombre.IdCarrera)
                            {
                                ModelState.AddModelError("", "Ya existe una carrera con el mismo nombre (datos duplicados) ");
                                return View(carreraVM);
                            }
                        }
                        if (carreraResultClave != null)
                        {
                            if (carreraVM.IdCarrera != carreraResultClave.IdCarrera)
                            {
                                ModelState.AddModelError("", "Ya existe una carrera con la misma clave (datos duplicados)");
                                return View(carreraVM);
                            }
                        }
                        
                        carreraRepository.UpdateCarreraVM(carreraVM);
                        return RedirectToAction("Carrera", "Administrador");
                        
                    }
                    else if (carreraResult.IdCarrera == carreraVM.IdCarrera)
                    {
                       
                        if (carreraResultNombre != null)
                        {
                            if (carreraVM.IdCarrera != carreraResultNombre.IdCarrera)
                            {
                                ModelState.AddModelError("", "Ya existe una carrera con el mismo nombre (datos duplicados) ");
                                return View(carreraVM);
                            }
                        }
                        if (carreraResultClave != null)
                        {
                            if (carreraVM.IdCarrera != carreraResultClave.IdCarrera)
                            {
                                ModelState.AddModelError("", "Ya existe una carrera con la misma clave (datos duplicados)");
                                return View(carreraVM);
                            }
                        }

                        carreraResult.Clave = carreraVM.Clave;
                        carreraResult.Nombre = carreraVM.Nombre;
                        carreraRepository.Update(carreraResult);

                        return RedirectToAction("Carrera", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe esta carrera");
                        return View(carreraVM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(carreraVM);
                }
            }
            else
            {
                return View(carreraVM);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(CarreraViewModel carreraVM)
        {
            CarrerasRepository carrerasRepostery = new CarrerasRepository();
            var carreraResult = carrerasRepostery.GetById(carreraVM.IdCarrera);
            if (carreraResult != null)
            {
                carrerasRepostery.Delete(carreraResult);
            }
            return RedirectToAction("Carrera", "Administrador");
        }
    }
}