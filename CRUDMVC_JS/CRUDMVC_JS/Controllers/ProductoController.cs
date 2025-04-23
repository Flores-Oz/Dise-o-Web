using CRUDMVC_JS.Data.Context;
using CRUDMVC_JS.Data.CreateModels;
using CRUDMVC_JS.Data.DtoModel;
using CRUDMVC_JS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUDMVC_JS.Controllers
{
    public class ProductoController : Controller
    {
        BDContextMVC _context = new BDContextMVC();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> getMarcas()
        {
            //public async Task<IActionResult> getMarcas(int idMarca)
            var marcas = _context.Marcas.Select(mr => new SelectListItem
            {
                Text = mr.NombreMarca,
                Value = mr.CodigoMarca.ToString()
            });
            return Ok(marcas);
        }

        public async Task<IActionResult> getProductos()
        {
            var productos = await _context.Productos.Select(pr => new ProductoModel
            {
                codigo = pr.CodigoProducto,
                nombre = pr.NombreProducto.ToString(),
                precioc = pr.PrecioCosto,
                preciov = pr.PrecioVenta,
                existencia = pr.ExistenciaProducto,
                marca = pr.CodigoModeloNavigation.CodigoMarcaNavigation.NombreMarca

            }).ToListAsync();

            return Ok(productos);
        }

        public async Task<IActionResult> getModelo(int idMarca)
        {
            {
                var Modelo = await _context.Modelos.Select(mr => new SelectListItem
                {
                    Value = mr.CodigoModelo.ToString(),
                    Text = mr.NombreModelo
                }).ToListAsync();
                return Ok(Modelo);
            }

        }
        [HttpPost]
        //FromBody se envia como modelo para agregarle referencias
        public async Task<IActionResult> postProducto([FromBody] ProductoModel datos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                Producto nuevop = new Producto
                {
                    CodigoProducto = datos.codigo,
                    NombreProducto = datos.nombre,
                    PrecioCosto = datos.precioc,
                    PrecioVenta = datos.preciov,
                    ExistenciaProducto = datos.existencia,
                    CodigoModelo = datos.codigoModelo
                };
                _context.Productos.Add(nuevop);
                await _context.SaveChangesAsync();
                respuesta.Data = true;
                respuesta.message = "Se ingreso Correctamente el Producto";
            }
            catch(Exception ex)
            {
                respuesta.Data = false;
                respuesta.message = "Hubo un Error";
            }
            return Ok(true);
        }
    }
}
