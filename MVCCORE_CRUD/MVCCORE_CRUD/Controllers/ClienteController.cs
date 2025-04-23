using Microsoft.AspNetCore.Mvc;

namespace MVCCORE_CRUD.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
