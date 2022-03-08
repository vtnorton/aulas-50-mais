using BancoRoxinho.Dominio.Model;
using BancoRoxinho.Dominio.Services;
using Microsoft.AspNetCore.Mvc;


namespace BancoRoxinho.Controllers
{
    public class PessoaFisicaController : Controller
    {
        PessoaFisicaService pessoaFisicaService = new PessoaFisicaService();

        public ActionResult Index()
        {
            var listaObtida = pessoaFisicaService.ObterLista();
            return View(listaObtida);
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(PessoaFisica pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.CPF)) // Error 500
                return BadRequest("Não é possível adicionar uma pessoa sem CPF.");

            pessoaFisicaService.Adicionar(pessoa);

            return Redirect("/PessoaFisica/Index");
        }
    }
}
