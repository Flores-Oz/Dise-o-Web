using CRUDMVC_JS.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        
    }
}
