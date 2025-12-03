using Microsoft.AspNetCore.Mvc;
using ModeloVistaControlador.Models;
using System.Data;
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


            ViewBag.TituloPagina = "Mi perfil de Usuario";
            ViewData["FechaActual"] = DateTime.Now.ToShortDateString();

            return View(modelo);

        }

    }
}
