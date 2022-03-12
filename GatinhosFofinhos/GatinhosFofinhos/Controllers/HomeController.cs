using GatinhosFofinhos.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GatinhosFofinhos.Controllers
{
    public class HomeController : Controller
    {
        private MainService _mainService;

        public HomeController(IConfiguration configuration)
        {
            _mainService = new MainService(configuration);
        }

        public IActionResult Index()
        {
            var listaDeCategorias = _mainService.ObterLista();
            return View(listaDeCategorias);
        }
    }
}
