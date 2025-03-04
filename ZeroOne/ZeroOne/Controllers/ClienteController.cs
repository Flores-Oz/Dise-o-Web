using Microsoft.AspNetCore.Mvc;
using ZeroOne.Data.Context;
using ZeroOne.Data.Models;

namespace ZeroOne.Controllers
{
    public class ClienteController : Controller
    {
        BDContextMVC bd = new BDContextMVC();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult buscaCliente(string nit)
        {
            var bcliente = new Cliente();
            if (nit != null)
            {
                bcliente = (from ca in bd.Clientes
                            where ca.NitCliente == nit
                            select ca).FirstOrDefault();
            }
            return View("ClienteO" +
                "", bcliente);
        }
        public IActionResult guardarCarrera(Cliente nuevoCLiente)
        {
            bd.Clientes.Add(nuevoCLiente);
            bd.SaveChanges();
            return View("Index", ListadoCarreras());
        }
        public IActionResult editarCarrera(Cliente Cliente)
        {
            var consulta = (from ca in bd.Clientes
                            where ca.NitCliente == Cliente.NitCliente
                            select ca).FirstOrDefault();
            if (consulta != null)
            {
                bd.SaveChanges();

            }
            return View("Index", ListadoCarreras());
        }

        public IActionResult eliminarCarrera(string nit)
        {
            var consulta = from ca in bd.Clientes
                           where ca.NitCliente == nit
                           select ca;
            bd.Clientes.Remove(consulta.FirstOrDefault());
            bd.SaveChanges();
            return View("Index", ListadoCarreras());
        }

        //Funciones
        private List<Cliente> ListadoCarreras()
        {
            var listado = from s in bd.Clientes
                          select s;
            return listado.ToList();
        }
    }
}
