using Microsoft.AspNetCore.Mvc;

namespace Nivel2.Controllers
{
    public class BlogController : Controller
    {

        public IActionResult Articulo(int id)
        {

            ViewBag.Mensaje = $"Cargando articulo id: {id}";
            Console.WriteLine(ViewBag.Mensaje);
            return View();
        }
    }
}
