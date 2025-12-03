using Microsoft.AspNetCore.Mvc;
using TagHelpers.Models;


public class MovieController : Controller
{
    // GET: mostrar formulario Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: recibir datos del formulario
    [HttpPost]
    public IActionResult Create(Movie model)
    {
        if (ModelState.IsValid)
        {
            // Aquí normalmente guardarías en base de datos
            return RedirectToAction("Index");
        }

        // Si hay errores de validación
        return View(model);
    }

    // GET: listado de películas (para probar el href)
    public IActionResult Index()
    {
        // Vista mínima, puede estar vacía
        return View();
    }
}
