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
    public class RolController : Controller
    {
        //GET --------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            RolesRepository rolesRepository = new RolesRepository();
            IEnumerable<Rol> rolesIEnumerable = rolesRepository.GetAll();
            return View(rolesIEnumerable);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            RolesRepository rolesRepository = new RolesRepository();
            var rolResult = rolesRepository.GetRolById(id);
            return View(rolResult);
        }

        public IActionResult Eliminar(int id)
        {
            RolesRepository rolesRepository = new RolesRepository();
            var rolResult = rolesRepository.GetRolById(id);
            return View(rolResult);
        }

        //POST --------------------------------------------------------------------------------------
        [HttpPost]
        public IActionResult Agregar(RolViewModel rolVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RolesRepository rolesRepository = new RolesRepository();
                    var rolResult = rolesRepository.GetRolByNombre(rolVM.Nombre.ToLower());

                    Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    bool resultado = true;
                    resultado = regex.IsMatch(rolVM.Nombre);

                    if (!resultado)
                    {
                        ModelState.AddModelError("", "No se aceptan caracteres especiales (Solo: a-z, A-Z, 0-9).");
                        return View(rolVM);
                    }
                    Regex regexNoNumStart = new Regex(@"[0-9]$");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = rolVM.Nombre.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con número.");
                        return View(rolVM);
                    }

                    if (rolResult == null)
                    {
                        rolesRepository.InsertRolVM(rolVM);

                        return RedirectToAction("Rol", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe un Rol con el mismo nombre.");
                        return View(rolVM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(rolVM);
                }
            }
            else
            {
                return View(rolVM);
            }
        }

        [HttpPost]
        public IActionResult Editar(RolViewModel rolVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RolesRepository rolesRepository = new RolesRepository();
                    var rolResult = rolesRepository.GetRolByNombre(rolVM.Nombre.ToLower());

                    Regex regex = new Regex(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s 0-9 ]+$");
                    bool resultado = true;
                    resultado = regex.IsMatch(rolVM.Nombre);

                    if (!resultado)
                    {
                        ModelState.AddModelError("", "No se aceptan caracteres especiales (Solo: a-z, A-Z, 0-9).");
                        return View(rolVM);
                    }

                    Regex regexNoNumStart = new Regex(@"[0-9]$");
                    bool resultadoNoNumStart = false;
                    string textoFirstChart = rolVM.Nombre.Substring(0, 1);
                    resultadoNoNumStart = regexNoNumStart.IsMatch(textoFirstChart);
                    if (resultadoNoNumStart)
                    {
                        ModelState.AddModelError("", "No se permite iniciar con número.");
                        return View(rolVM);
                    }

                    if (rolResult == null)
                    {
                        rolesRepository.UpdateRolVM(rolVM);

                        return RedirectToAction("Rol", "Administrador");
                    }
                    else if (rolResult.IdRol == rolVM.IdRol)
                    {
                        rolResult.Nombre = rolVM.Nombre;
                        rolesRepository.Update(rolResult);

                        return RedirectToAction("Rol", "Administrador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ya existe este rol.");
                        return View(rolVM);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(rolVM);
                }
            }
            else
            {
                return View(rolVM);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(RolViewModel rolVM)
        {
            RolesRepository rolesRepository = new RolesRepository();
            var rolResult = rolesRepository.GetById(rolVM.IdRol);

            if (rolResult != null)
            {
                rolesRepository.Delete(rolResult);
            }

            return RedirectToAction("Rol", "Administrador");
        }
    }
}