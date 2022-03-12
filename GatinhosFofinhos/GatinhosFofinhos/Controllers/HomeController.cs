using Microsoft.AspNetCore.Mvc;

namespace GatinhosFofinhos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
