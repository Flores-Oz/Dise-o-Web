using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2.Data.Context;
using Parcial2.Data.CreateModels;
using Parcial2.Data.DtoModel;
using Parcial2.Data.Models;

namespace Parcial2.Controllers
{
    public class PacienteController : Controller
    {
        BDContextMVC _context = new BDContextMVC();
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
            var pacientes = await _context.Pacientes.Select(pr => new PacienteModel
            {
                CodigoPaciente = pr.CodigoPaciente,
                DpiPaciente = pr.DpiPaciente,
                NombrePaciente = pr.NombrePaciente,
                ApellidoPaciente = pr.ApellidoPaciente,
                FechaNac = pr.FechaNac,
                EstadoPaciente = pr.EstadoPaciente,
                Municipio = pr.CodigoMunicipioNavigation.NombreMunicipio,
                Departamento = pr.CodigoMunicipioNavigation.CodigoDepartamentoNavigation.NombreDepartamento

            }).ToListAsync();

            return Ok(pacientes);
        }

        public async Task<IActionResult> deletePaciente(int codigoPaciente)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                var paciente = await _context.Pacientes.Where(pr => pr.CodigoPaciente == codigoPaciente).FirstOrDefaultAsync();
                if (paciente != null)
                {
                    _context.Pacientes.Remove(paciente);
                    await _context.SaveChangesAsync();
                    respuesta.message = "Se elimino el Paciente";
                    respuesta.Data = true;
                }
            }
            catch (Exception ex)
            {
                respuesta.message = "Ocurrio un error";
                respuesta.Data = false;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> postProducto([FromBody] PacienteModel datos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                Paciente nuevop = new Paciente
                {
                    CodigoPaciente = datos.CodigoPaciente,
                    DpiPaciente  = datos.DpiPaciente,
                    NombrePaciente = datos.NombrePaciente,
                    ApellidoPaciente = datos.ApellidoPaciente,
                    FechaNac = datos.FechaNac,
                    EstadoPaciente = datos.EstadoPaciente,
                    CodigoMunicipio = datos.CodigoMunicipio
                };
                _context.Pacientes.Add(nuevop);
                await _context.SaveChangesAsync();
                respuesta.Data = true;
                respuesta.message = "Se ingreso Correctamente al Paciente";
            }
            catch (Exception ex)
            {
                respuesta.Data = false;
                respuesta.message = ex.Message.ToString();

            }


            return Ok(respuesta);
        }
        [HttpPut]
        public async Task<IActionResult> putProducto([FromBody] PacienteModel pacientedatos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                var paciente = await _context.Pacientes
                    .Where(pr => pr.CodigoPaciente == pacientedatos.CodigoPaciente)
                    .FirstOrDefaultAsync();
                if (paciente != null)
                {
                    paciente.NombrePaciente = pacientedatos.NombrePaciente;
                    paciente.ApellidoPaciente = pacientedatos.ApellidoPaciente;
                    paciente.FechaNac = pacientedatos.FechaNac;
                    paciente.EstadoPaciente = pacientedatos.EstadoPaciente;
                    paciente.CodigoMunicipio = pacientedatos.CodigoMunicipio;
                    await _context.SaveChangesAsync();
                    respuesta.message = "Se edito al Paciente";
                    respuesta.Data = true;
                }


            }
            catch (Exception ex)
            {
                respuesta.message = ex.Message;
                respuesta.Data = false;
            }
            return Ok(respuesta);
        }
    }
}
