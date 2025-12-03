using Microsoft.AspNetCore.Mvc;
using Ejercicio_2._2.Models;


namespace Ejercicio_2._2.Controllers
{
    public class CuentaController : Controller
    {

        // GET: muestra el formulario
        public IActionResult Login()
        {
            return View();
        }

        // POST: recibe los datos del formulario
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            // Verificar que el ModelState sea válido
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Simulación de autenticación básica
            if (model.Usuario == "admin")
            {
                // Redirigimos a la acción Perfil del controlador Usuario
                return RedirectToAction("Perfil", "Usuario");
            }

            ViewBag.Mensaje = "Usuario incorrecto. Inténtalo de nuevo.";
            return View(model);
        }
    }
}
