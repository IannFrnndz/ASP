using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCRUDSencilla.Models;

namespace WebMVCRUDSencilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // **Nueva Colección Estática:** Simula la Base de Datos.
        // Se inicializa una sola vez cuando la clase se carga.
        private static List<Estudiante> _listaEstudiantes = new List<Estudiante>
        {
            new Estudiante { Id = 1, Nombre = "Ana García", Curso = "C# Básico", Edad = 20 },
            new Estudiante { Id = 2, Nombre = "Luis Pérez", Curso = "ASP.NET Core", Edad = 22 },
            new Estudiante { Id = 3, Nombre = "Marta Ruiz", Curso = "MVC", Edad = 21 }
        };



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // R: Read (Leer todos)
        public IActionResult Index()
        {
            // Ahora devolvemos la lista estática
            return View(_listaEstudiantes);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // C: Create (Mostrar Formulario - GET)
        // URL: /Home/Crear
        public IActionResult Crear()
        {
            // Simplemente devuelve una vista vacía para el formulario
            return View();
        }

        // C: Create (Procesar Formulario - POST)
        [HttpPost] // Indica que solo maneja solicitudes POST
        [ValidateAntiForgeryToken] // Buena práctica de seguridad
        public IActionResult Crear(Estudiante nuevoEstudiante)
        {
            if (ModelState.IsValid) // Verifica si el modelo cumple las reglas
            {
                // 1. Asignar un nuevo ID
                int nextId = _listaEstudiantes.Any() ? _listaEstudiantes.Max(e => e.Id) + 1 : 1;
                nuevoEstudiante.Id = nextId;

                // 2. Añadir a la "base de datos" (la lista estática)
                _listaEstudiantes.Add(nuevoEstudiante);

                // 3. Redirigir al listado (patrón PRG - Post/Redirect/Get)
                return RedirectToAction(nameof(Index));
            }
            // Si el modelo no es válido, vuelve a mostrar el formulario con los datos ingresados
            return View(nuevoEstudiante);
        }

    }
}