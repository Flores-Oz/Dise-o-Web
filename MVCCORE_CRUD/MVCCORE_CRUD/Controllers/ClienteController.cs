using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCORE_CRUD.Data.Context;
using MVCCORE_CRUD.Data.CreateModels;
using MVCCORE_CRUD.Data.DtoModel;
using MVCCORE_CRUD.Data.Models;

namespace MVCCORE_CRUD.Controllers
{
    public class ClienteController : Controller
    {
        MVCContext _context = new MVCContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> getDepartamentos(int idDepa)
        {
            var Depa = await _context.Departamentos.Select(mr => new SelectListItem
            {
                Text = mr.NombreDepartamento,
                Value = mr.CodigoDepartamento.ToString()
            }).ToListAsync();
            return Ok(Depa);
        }
        public async Task<IActionResult> getMunicipio(int idDepa)
        {
            var municipios = await _context.Municipios.Where(md => md.CodigoDepartamento == idDepa).Select(md => new SelectListItem
            {
                Value = md.CodigoMunicipio.ToString(),
                Text = md.NombreMunicipio.ToString()
            }).ToListAsync();

            return Ok(municipios);
        }
        public async Task<IActionResult> getClientes()
        {
            var clientes = await _context.Clientes.Select(pr => new ClienteModel
            {
                NitCliente = pr.NitCliente,
                NombreCliente = pr.NombreCliente,
                ApellidoCliente = pr.ApellidoCliente,
                DireccionCliente = pr.DireccionCliente,
                TelefonoCliente = pr.TelefonoCliente,
                FechanacCliente = pr.FechanacCliente,
                EstadoCliente = pr.EstadoCliente,
                Municipio = pr.CodigoMunicipioNavigation.NombreMunicipio,
                Departamento = pr.CodigoMunicipioNavigation.CodigoDepartamentoNavigation.NombreDepartamento

            }).ToListAsync();

            return Ok(clientes);
        }
    }
}
