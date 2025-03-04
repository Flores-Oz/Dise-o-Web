using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZeroOne.Controllers
{
    public class MunicipioController : Controller
    {
        public ActionResult Index()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            using(Data.Context.BDContextMVC db = new Data.Context.BDContextMVC())
            {
                list = (from d in db.Municipios
                        select new SelectListItem
                        {
                            Value = d.CodigoDepartamento.ToString(),
                            Text = d.NombreMunicipio
                        }).ToList();
            }
            return View(list);
        }
    }
}
