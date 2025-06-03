using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDFGenerator.Data.Context;
using PDFGenerator.Data.DtoModel;
using PDFGenerator.Data.Models;
using PDFGenerator.Models;

namespace PDFGenerator.Controllers
{
    public class FacturaController : Controller
    {
        private readonly PdfDbContext _context;

        public FacturaController(PdfDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var depas = await _context.Productos.Select(d => new SelectListItem
            {
                Text = d.Nombre,
                Value = d.Id.ToString()
            }).ToListAsync();
            return Ok(depas);
        }
    }
}
