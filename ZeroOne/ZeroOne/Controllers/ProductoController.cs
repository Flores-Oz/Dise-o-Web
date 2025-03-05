using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZeroOne.Data.Context;
using ZeroOne.Data.Models;
using ZeroOne.Models;

namespace ZeroOne.Controllers
{
    public class ProductoController : Controller
    {
        BDContextMVC db = new BDContextMVC();
        public IActionResult Producto()
        {
            var listado = db.Productos.Select(pro => new ProductoModel
            {
                CodigoProducto = pro.CodigoProducto,
                NombreProducto = pro.NombreProducto,
                PrecioCosto = pro.PrecioCosto,
                PrecioVenta = pro.PrecioVenta,
                ExistenciaProducto = pro.ExistenciaProducto,
                CodigoMarca = pro.CodigoMarca,
                nombreMarca = pro.CodigoMarcaNavigation.NombreMarca
            }).ToList();

            return View(listado);
        }
        public IActionResult buscarProducto(int codProd)
        {
            var marcas = from ma in db.Marcas
                         select new SelectListItem
                         {
                             Value = ma.CodigoMarca.ToString(),
                             Text = ma.NombreMarca
                         };
            ViewBag.Marcas = marcas.ToList();
            var listado = from pro in db.Productos
                          select new ProductoModel
                          {
                              CodigoProducto = pro.CodigoProducto,
                              NombreProducto = pro.NombreProducto,
                              PrecioCosto = pro.PrecioCosto,
                              PrecioVenta = pro.PrecioVenta,
                              ExistenciaProducto = pro.ExistenciaProducto,
                              CodigoMarca = pro.CodigoMarca,
                              nombreMarca = pro.CodigoMarcaNavigation.NombreMarca
                          };
            
            var consulta = from pro in db.Productos
                           where pro.CodigoProducto == codProd
                           select pro;
            return View("CRUDProducto",consulta.FirstOrDefault());
        }

        public List<Producto> ListadoProductos()
        {
            var listado = from pro in db.Productos
                          select pro;
            return listado.ToList();
        }
    }
}
