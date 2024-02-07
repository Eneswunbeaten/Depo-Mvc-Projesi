using Microsoft.AspNetCore.Mvc;

namespace MvcStok.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
