using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCORE_CRUD.Data.Context;
using MVCCORE_CRUD.Data.CreateModels;
using MVCCORE_CRUD.Data.DtoModel;
using MVCCORE_CRUD.Data.Models;

namespace MVCCORE_CRUD.Controllers
{
    public class ProductoController : Controller
    {
        MVCContext _context = new MVCContext(); 
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> getMarcas(int idModelo)
        {
            int m = idModelo;
            var marcas = await _context.Marcas.Select(mr => new SelectListItem
            {
                Text = mr.NombreMarca,
                Value = mr.CodigoMarca.ToString()
            }).ToListAsync();
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
                marca = pr.CodigoModeloNavigation.CodigoMarcaNavigation.NombreMarca,
                codigomarca = (int)pr.CodigoModeloNavigation.CodigoMarca,
                codigomodelo = pr.CodigoModelo

            }).ToListAsync();

            return Ok(productos);
        }

        public async Task<IActionResult> getModelo(int idmarca)
        {
            var modelos = await _context.Modelos.Where(md => md.CodigoMarca == idmarca).Select(md => new SelectListItem
            {
                Value = md.CodigoModelo.ToString(),
                Text = md.NombreModelo.ToString()
            }).ToListAsync();

            return Ok(modelos);
        }
        public async Task<IActionResult> deleteProdcuto(int codigoproducto)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                var producto = await _context.Productos.Where(pr => pr.CodigoProducto == codigoproducto).FirstOrDefaultAsync();
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    await _context.SaveChangesAsync();
                    respuesta.message = "Se elimino el producto";
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
        public async Task<IActionResult> postProducto([FromBody] ProductoModel datos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                Producto nuevop = new Producto
                {

                    NombreProducto = datos.nombre,
                    PrecioCosto = datos.precioc,
                    PrecioVenta = datos.preciov,
                    ExistenciaProducto = datos.existencia,
                    CodigoModelo = datos.codigomodelo
                };
                _context.Productos.Add(nuevop);
                await _context.SaveChangesAsync();
                respuesta.Data = true;
                respuesta.message = "Se ingreso Correctamente el producto";
            }
            catch (Exception ex)
            {
                respuesta.Data = false;
                respuesta.message = ex.Message.ToString();

            }


            return Ok(respuesta);
        }
        [HttpPut]
        public async Task<IActionResult> putProducto([FromBody] ProductoModel productodatos)
        {
            var respuesta = new ResponseModel<bool>();
            try
            {
                var producto = await _context.Productos
                    .Where(pr => pr.CodigoProducto == productodatos.codigo)
                    .FirstOrDefaultAsync();
                if (producto != null)
                {
                    producto.NombreProducto = productodatos.nombre;
                    producto.PrecioCosto = productodatos.precioc;
                    producto.PrecioVenta = productodatos.preciov;
                    producto.ExistenciaProducto = productodatos.existencia;
                    producto.CodigoModelo = productodatos.codigomodelo;
                    await _context.SaveChangesAsync();
                    respuesta.message = "Se edito el producto";
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
