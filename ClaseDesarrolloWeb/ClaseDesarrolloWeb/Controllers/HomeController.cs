using ClaseDesarrolloWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClaseDesarrolloWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*ViewBag*/
            ViewBag.Nombre = "Oscar";
            ViewBag.Edad = 36;
            ViewData["Mensaje"] = "Buenas";
            return View("Index","Perez");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Prueba()
        {
            return View();
        }
        public IActionResult CRUD()
        {
            
            PersonaModel persona = new PersonaModel {
                Codigo = 123,
                Nombre = "Os",
                Apellidos = "MAD",
                Edad = 25
            };
            List<PersonaModel> misPersonas = new List<PersonaModel> { 
                new PersonaModel
                {
                      Codigo = 123,
                Nombre = "Os",
                Apellidos = "MAD",
                Edad = 25
                },
                new PersonaModel
                {
                      Codigo = 456,
                Nombre = "Ds",
                Apellidos = "MAD",
                Edad = 20
                },
                new PersonaModel {
                      Codigo = 789,
                Nombre = "az",
                Apellidos = "MAD",
                Edad = 21
                },
                new PersonaModel
                {
                      Codigo = 123,
                Nombre = "ds",
                Apellidos = "MAD",
                Edad = 2
                }
            };
            //Crear la lista de elementos
            var listado = from s in misPersonas
                         select new SelectListItem
                         {
                             Value = s.Codigo.ToString() ,
                             Text = s.Nombre + " " + s.Apellidos
                         }; /*SelectListItem sirve para rellenar con la plantilla que quiero*/
            ViewBag.Personas = listado.ToList();
            return View("CRUD",misPersonas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
