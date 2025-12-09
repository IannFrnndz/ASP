using Microsoft.AspNetCore.Mvc;
namespace ContoladoresYVistasA3._6.Controllers
{
    public class ProductosController : Controller
    {

        public IActionResult Index()
        {
            // utilizamos dynamic para crear la lisya por que no tenemos un modelo con los datos de los productos
            var productos = new List<dynamic>
            {
                new { Nombre = "Teclado", Precio = 25m },
                new { Nombre = "Ratón Gamer", Precio = 60m },
                new { Nombre = "Monitor 24\"", Precio = 120m },
                new { Nombre = "Alfombrilla", Precio = 10m }
            };

            ViewBag.Productos = productos;

            return View();
        }
    }
}
