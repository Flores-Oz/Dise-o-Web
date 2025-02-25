using ClaseDesarrolloWeb.Data.Context;
using ClaseDesarrolloWeb.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace ClaseDesarrolloWeb.Controllers
{
    public class CarreraController : Controller
    {
        BDContextMVC bd = new BDContextMVC();
        public IActionResult Index()
        {
            return View(ListadoCarreras());
        }
        public IActionResult buscaCarrrera(string idCar)
        {
            var bcarrera = new Carrera();
            if (idCar != null) { 
                bcarrera = (from ca in bd.Carreras
                           where ca.IdCarrera == idCar
                           select ca).FirstOrDefault();
            }
            return View("CrudCarrrera",bcarrera);
        }
        public IActionResult guardarCarrera(Carrera nuevaCarrera) 
        { 
            bd.Carreras.Add(nuevaCarrera);
            bd.SaveChanges();
            return View("Index", ListadoCarreras()); 
        }
        public IActionResult editarCarrera(Carrera Carrera)
        {
            var consulta = (from ca in bd.Carreras
                           where ca.IdCarrera == Carrera.IdCarrera
                           select ca).FirstOrDefault();
            if (consulta != null)
            {
                    consulta.NombreCarrera = Carrera.NombreCarrera;
                    consulta.EstadoCarrera = Carrera.EstadoCarrera;
                    bd.SaveChanges();
                
            }
            return View("Index", ListadoCarreras());
        }

        public IActionResult eliminarCarrera(string idCar)
        {
            var consulta = from ca in bd.Carreras
                           where ca.IdCarrera == idCar
                           select ca;
            bd.Carreras.Remove(consulta.FirstOrDefault());
            bd.SaveChanges();
            return View("Index", ListadoCarreras());
        }

        //Funciones
        private List<Carrera> ListadoCarreras()
        {
            var listado = from s in bd.Carreras
                          select s;
            return listado.ToList();
        }
    }
}
