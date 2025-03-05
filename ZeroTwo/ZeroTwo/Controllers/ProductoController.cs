using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZeroTwo.Data.Context;
using ZeroTwo.Data.Models;
using ZeroTwo.Models;

namespace ZeroTwo.Controllers
{
    public class ProductoController : Controller
    {
        BDContextMVC db = new BDContextMVC();
        public IActionResult Index()
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
            IQueryable<Producto> consulta = ;
            if (codProd != 0) { 
            consulta  = from pro in db.Productos
                           where pro.CodigoProducto == codProd
                           select pro;
            }
            else
            {
                codProd = 0;
            }
            return View("CRUDProducto", consulta.FirstOrDefault());
        }

        public IActionResult guardarProducto(Producto nuevoProducto)
        {
            db.Productos.Add(nuevoProducto);
            db.SaveChanges();
            return View("Index", ListadoProductos());
        }
        public IActionResult editarProducto(ProductoModel Producto)
        {
            var consulta = (from ca in db.Productos
                            where ca.CodigoProducto == Producto.CodigoProducto
                            select ca).FirstOrDefault();
            if (consulta != null)
            {
                consulta.NombreProducto = Producto.NombreProducto;
                consulta.PrecioCosto = Producto.PrecioCosto;
                consulta.PrecioVenta = Producto.PrecioVenta;
                consulta.ExistenciaProducto = Producto.ExistenciaProducto;
                consulta.CodigoMarca = Producto.CodigoMarca;
                db.SaveChanges();
            }
            return View("Index", ListadoProductos());
        }

        public IActionResult eliminarProducto(int idPro)
        {
            var consulta = from ca in db.Productos
                           where ca.CodigoProducto == idPro
                           select ca;
            db.Productos.Remove(consulta.FirstOrDefault());
            db.SaveChanges();
            return View("Index", ListadoProductos());
        }

        public List<ProductoModel> ListadoProductos()
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
            });
            return listado.ToList();
        }

    }
}
