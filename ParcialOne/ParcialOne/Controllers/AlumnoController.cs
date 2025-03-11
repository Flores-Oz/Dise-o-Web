using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParcialOne.Data.Context;
using ParcialOne.Data.Models;
using ParcialOne.Models;

namespace ParcialOne.Controllers
{
    public class AlumnoController : Controller
    {
        BDContextMVC db = new BDContextMVC();
        public IActionResult Index()
        {
            return View(ListadoAlumnos());
        }

        public IActionResult buscaAlumnos(string carne)
        {
            var carreras = from car in db.Carreras
                           select new SelectListItem
                           {
                               Value = car.CodigoCarrera.ToString(),
                               Text = car.NombreCarrera
                           };
            ViewBag.Carreras = carreras.ToList();
            var listado = from pro in db.Alumnos
                          where pro.CarneAlumno == carne
                          select new AlumnoModel
                          {
                              CarneAlumno = pro.CarneAlumno,
                              Nombre1Alumno = pro.Nombre1Alumno,
                              Nombre2Alumno = pro.Nombre2Alumno,
                              Apellido1Alumno = pro.Apellido1Alumno,
                              Apellido2Alumno = pro.Apellido2Alumno,
                              FechaNacimiento = pro.FechaNacimiento,
                              DireccionAlumno = pro.DireccionAlumno,
                              TelefonoAlumno = pro.TelefonoAlumno,
                              CorreoAlumno = pro.CorreoAlumno,
                              CodigoCarrera = pro.CodigoCarrera,
                              Carrera = pro.CodigoCarreraNavigation.NombreCarrera
                          };
            var consulta = new Alumno();
            if (carne != null)
            {
                consulta = (from pro in db.Alumnos
                               where pro.CarneAlumno == carne
                               select pro).FirstOrDefault();
               
            }
            return View("CRUDAlumnos", consulta);
        }

        public IActionResult guardarAlumno(Alumno nuevoAlumno)
        {
            db.Alumnos.Add(nuevoAlumno);
            db.SaveChanges();
            return View("Index", ListadoAlumnos());
        }
        public IActionResult editarAlumno(Alumno Alumno)
        {
            var consulta = (from ca in db.Alumnos
                            where ca.CarneAlumno == Alumno.CarneAlumno
                            select ca).FirstOrDefault();
            if (consulta != null)
            {
                consulta.Nombre1Alumno = Alumno.Nombre1Alumno;
                consulta.Nombre2Alumno = Alumno.Nombre2Alumno;
                consulta.Apellido1Alumno = Alumno.Apellido1Alumno;
                consulta.Apellido2Alumno = Alumno.Apellido2Alumno;
                consulta.FechaNacimiento = Alumno.FechaNacimiento;
                consulta.DireccionAlumno = Alumno.DireccionAlumno;
                consulta.TelefonoAlumno = Alumno.TelefonoAlumno;
                consulta.CorreoAlumno = Alumno.CorreoAlumno;
                consulta.CodigoCarrera = Alumno.CodigoCarrera;
                db.SaveChanges();
            }
            return View("Index", ListadoAlumnos());
        }

        public IActionResult eliminarAlumno(string Carne)
        {
            var consulta = from ca in db.Alumnos
                           where ca.CarneAlumno == Carne
                           select ca;
            db.Alumnos.Remove(consulta.FirstOrDefault());
            db.SaveChanges();
            return View("Index", ListadoAlumnos());
        }

        public List<AlumnoModel> ListadoAlumnos()
        {
            var listado = db.Alumnos.Select(pro => new AlumnoModel
            {
                CarneAlumno = pro.CarneAlumno,
                Nombre1Alumno = pro.Nombre1Alumno,
                Nombre2Alumno = pro.Nombre2Alumno,
                Apellido1Alumno = pro.Apellido1Alumno,
                Apellido2Alumno = pro.Apellido2Alumno,
                FechaNacimiento = pro.FechaNacimiento,
                DireccionAlumno = pro.DireccionAlumno,
                TelefonoAlumno = pro.TelefonoAlumno,
                CorreoAlumno = pro.CorreoAlumno,
                CodigoCarrera = pro.CodigoCarrera,
                Carrera = pro.CodigoCarreraNavigation.NombreCarrera
            });
            return listado.ToList();
        }
    }
}
