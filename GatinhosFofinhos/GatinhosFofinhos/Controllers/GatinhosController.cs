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

        [Route("Gatinhos/Visualizar/{id}")]
        public async Task<IActionResult> Visualizar([FromRoute] int id)
        {
            var categoria = await _mainService.ObterVisualizacao(id);
            return View(categoria);
        }

        [Route("Gatinhos/Deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            _mainService.DeletarCategoria(id);
            return Redirect("/");
        }

        [HttpGet]
        [Route("Gatinhos/Editar/{id}")]
        public async Task<IActionResult> Editar([FromRoute] int id)
        {
            var categoria = _mainService.ObterCategoria(id);
            var listaDeCategorias = await _catAPIService.ObterLista();

            ViewData["CategoriasDaAPIDeGatos"] = listaDeCategorias;

            return View(categoria);
        }

        [HttpPost]
        [Route("Gatinhos/Editar/{id}")]
        public IActionResult Editar([FromRoute] int id, Categoria categoria)
        {
            // EDIÇÃO
            return Redirect("Gatinhos/Visualizar/" + id);
        }
    }
}
