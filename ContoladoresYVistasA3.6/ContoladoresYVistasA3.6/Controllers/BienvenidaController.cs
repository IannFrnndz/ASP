using Microsoft.AspNetCore.Mvc;

namespace ContoladoresYVistasA3._6.Controllers
{
    public class BienvenidaController : Controller
    {

        public IActionResult Index()
        {

            ViewBag.Nombre = "Ian";
            ViewBag.FechaActual = DateTime.Now;
            return View();
        }
    }
}
