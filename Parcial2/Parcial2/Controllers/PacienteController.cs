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
        public async Task<IActionResult> GetDepartamentos()
        {
            var depas = await _context.Departamentos.Select(d => new SelectListItem
            {
                Text = d.NombreDepartamento,
                Value = d.CodigoDepartamento.ToString()
            }).ToListAsync();
            return Ok(depas);
        }

        [HttpGet]
        public async Task<IActionResult> GetMunicipio(int idDepa)
        {
            var municipios = await _context.Municipios
                .Where(m => m.CodigoDepartamento == idDepa)
                .Select(m => new SelectListItem
                {
                    Text = m.NombreMunicipio,
                    Value = m.CodigoMunicipio.ToString()
                }).ToListAsync();
            return Ok(municipios);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var pacientes = await _context.Pacientes
                .Include(p => p.CodigoMunicipioNavigation)
                .ThenInclude(m => m.CodigoDepartamentoNavigation)
                .Select(p => new PacienteModel
                {
                    CodigoPaciente = p.CodigoPaciente,
                    DpiPaciente = p.DpiPaciente,
                    NombrePaciente = p.NombrePaciente,
                    ApellidoPaciente = p.ApellidoPaciente,
                    FechaNac = p.FechaNac,
                    EstadoPaciente = p.EstadoPaciente,
                    Municipio = p.CodigoMunicipioNavigation.NombreMunicipio,
                    Departamento = p.CodigoMunicipioNavigation.CodigoDepartamentoNavigation.NombreDepartamento,
                    CodigoMunicipio = p.CodigoMunicipio,
                    CodigoDepartamento = p.CodigoMunicipioNavigation.CodigoDepartamento
                }).ToListAsync();

            return Ok(pacientes);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaciente(int codigoPaciente)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                var paciente = await _context.Pacientes.FindAsync(codigoPaciente);
                if (paciente != null)
                {
                    _context.Pacientes.Remove(paciente);
                    await _context.SaveChangesAsync();
                    respuesta.Data = true;
                    respuesta.message = "Se eliminó el paciente correctamente.";
                }
                else
                {
                    respuesta.Data = false;
                    respuesta.message = "Paciente no encontrado.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Data = false;
                respuesta.message = $"Error: {ex.InnerException?.Message ?? ex.Message}";

            }

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> PostPaciente([FromBody] PacienteModel datos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
               
                var existe = await _context.Pacientes.AnyAsync(p => p.CodigoPaciente == datos.CodigoPaciente);
                if (existe)
                {
                    respuesta.Data = false;
                    respuesta.message = "Ya existe un paciente con ese código.";
                    return Ok(respuesta);
                }

                
                var nuevo = new Paciente
                {
                    CodigoPaciente = datos.CodigoPaciente, 
                    DpiPaciente = datos.DpiPaciente,
                    NombrePaciente = datos.NombrePaciente,
                    ApellidoPaciente = datos.ApellidoPaciente,
                    FechaNac = datos.FechaNac,
                    EstadoPaciente = datos.EstadoPaciente,
                    CodigoMunicipio = datos.CodigoMunicipio
                };

                _context.Pacientes.Add(nuevo);
                await _context.SaveChangesAsync();
                respuesta.Data = true;
                respuesta.message = "Paciente agregado correctamente.";
            }
            catch (Exception ex)
            {
                respuesta.Data = false;
                respuesta.message = $"Error: {ex.Message}";
            }
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PutPaciente([FromBody] PacienteModel datos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                var paciente = await _context.Pacientes.FindAsync(datos.CodigoPaciente);
                if (paciente != null)
                {
                    paciente.DpiPaciente = datos.DpiPaciente;
                    paciente.NombrePaciente = datos.NombrePaciente;
                    paciente.ApellidoPaciente = datos.ApellidoPaciente;
                    paciente.FechaNac = datos.FechaNac;
                    paciente.EstadoPaciente = datos.EstadoPaciente;
                    paciente.CodigoMunicipio = datos.CodigoMunicipio;

                    await _context.SaveChangesAsync();
                    respuesta.Data = true;
                    respuesta.message = "Paciente editado correctamente.";
                }
                else
                {
                    respuesta.Data = false;
                    respuesta.message = "Paciente no encontrado.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Data = false;
                respuesta.message = $"Error: {ex.InnerException?.Message ?? ex.Message}";
                
            }

            return Ok(respuesta);
        }
    }
}
