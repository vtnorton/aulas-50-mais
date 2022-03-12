using GatinhosFofinhos.Models;
using GatinhosFofinhos.Servico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GatinhosFofinhos.Controllers
{
    public class GatinhosController : Controller
    {
        private MainService _mainService;
        private CatAPIService _catAPIService;

        public GatinhosController(IConfiguration configuration)
        {
            _mainService = new MainService(configuration);
            _catAPIService = new CatAPIService(configuration);
        }

        [HttpGet]
        public async Task<IActionResult> AdicionarCategoria()
        {
            List<CategoriasDaAPIDeGatos> listaDeCategorias = await _catAPIService.ObterLista();

            ViewData["CategoriasDaAPIDeGatos"] = listaDeCategorias;

            return View();
        }

        [HttpPost]
        public IActionResult AdicionarCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Preencha os campos corretamente");
            }

            _mainService.Adicionar(categoria);
            return Redirect("/");
        }
    }
}
