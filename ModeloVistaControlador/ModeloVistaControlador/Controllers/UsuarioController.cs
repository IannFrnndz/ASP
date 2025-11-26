using Microsoft.AspNetCore.Mvc;
using ModeloVistaControlador.Models;
using System.Reflection;

namespace ModeloVistaControlador.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Perfil()
        {
            var modelo = new PerfilViewModel
            {
                Nombre = "Ian",
                Email = "ian.fernandez@gmail.com",
                EsAdmin = true
            };

            return View(modelo);

        }

    }
}
