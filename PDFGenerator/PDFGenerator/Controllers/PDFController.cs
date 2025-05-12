using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDFGenerator.Data.Context;
using PDFGenerator.Data.DtoModel;
using PDFGenerator.Data.Models;
using PDFGenerator.Models;

namespace PDFGenerator.Controllers
{
    public class PDFController : Controller
    {
        private readonly PdfDbContext _context;

        public PDFController(PdfDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            var depas = await _context.Departamentos.Select(d => new SelectListItem
            {
                Text = d.Nombre,
                Value = d.Id.ToString()
            }).ToListAsync();
            return Ok(depas);
        }

        [HttpGet]
        public async Task<IActionResult> GetMunicipio(int idDepa)
        {
            var municipios = await _context.Municipios
                .Where(m => m.DepartamentoId == idDepa)
                .Select(m => new SelectListItem
                {
                    Text = m.Nombre,
                    Value = m.Id.ToString()
                }).ToListAsync();
            return Ok(municipios);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _context.Clientes
                .Include(p => p.Municipio)
                .ThenInclude(m => m.Departamento)
                .Select(p => new ClienteModel
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Direccion = p.Direccion,
                    Telefono = p.Telefono,
                    Correo = p.Correo,
                    Municipio = p.Municipio.Nombre,
                    Departamento = p.Municipio.Departamento != null ? p.Municipio.Departamento.Nombre : string.Empty,
                    MunicipioId = p.MunicipioId,
                    CodigoDepartamento = p.Municipio.DepartamentoId ?? 0
                }).ToListAsync();

            return Ok(clientes);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCliente(int codigoCliente)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                var cliente = await _context.Clientes.FindAsync(codigoCliente);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    await _context.SaveChangesAsync();
                    respuesta.Data = true;
                    respuesta.message = "Se eliminó el Cliente correctamente.";
                }
                else

                {
                    respuesta.Data = false;
                    respuesta.message = "Cliente no encontrado.";
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
        public async Task<IActionResult> PostCliente([FromBody] ClienteModel datos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {

                var existe = await _context.Clientes.AnyAsync(p => p.Id == datos.Id);
                if (existe)
                {
                    respuesta.Data = false;
                    respuesta.message = "Ya existe un Cliente con ese ID.";
                    return Ok(respuesta);
                }


                var nuevo = new Cliente
                {
                    Id = datos.Id,
                    Nombre = datos.Nombre,
                    Direccion = datos.Direccion,
                    Telefono = datos.Telefono,
                    Correo = datos.Correo,
                    MunicipioId = datos.MunicipioId
                };

                _context.Clientes.Add(nuevo);
                await _context.SaveChangesAsync();
                respuesta.Data = true;
                respuesta.message = "Cliente agregado correctamente.";
            }
            catch (Exception ex)
            {
                respuesta.Data = false;
                respuesta.message = $"Error: {ex.Message}";
            }
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente([FromBody] ClienteModel datos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                // Verifica los datos recibidos
                if (datos == null)
                {
                    respuesta.Data = false;
                    respuesta.message = "Datos no recibidos correctamente.";
                    return BadRequest(respuesta);
                }

                var cliente = await _context.Clientes.FindAsync(datos.Id);
                if (cliente != null)
                {
                    cliente.Nombre = datos.Nombre;
                    cliente.Direccion = datos.Direccion;
                    cliente.Telefono = datos.Telefono;
                    cliente.Correo = datos.Correo;
                    cliente.MunicipioId = datos.MunicipioId;

                    await _context.SaveChangesAsync();
                    respuesta.Data = true;
                    respuesta.message = "Cliente editado correctamente.";
                }
                else
                {
                    respuesta.Data = false;
                    respuesta.message = "Cliente no encontrado.";
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
