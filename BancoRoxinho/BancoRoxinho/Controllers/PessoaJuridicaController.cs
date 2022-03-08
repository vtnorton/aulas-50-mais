using BancoRoxinho.Dominio.Model;
using BancoRoxinho.Dominio.Services;
using Microsoft.AspNetCore.Mvc;


namespace BancoRoxinho.Controllers
{
    public class PessoaJuridicaController : Controller
    {
        PessoaJuridicaService pessoaJuridicaService = new PessoaJuridicaService();

        public ActionResult Index()
        {
            var listaObtida = pessoaJuridicaService.ObterLista();
            return View(listaObtida);
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(PessoaJuridica pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.CNPJ)) // Error 500
                return BadRequest("Não é possível adicionar uma pessoa juridica sem CNPJ.");

            pessoaJuridicaService.Adicionar(pessoa);

            return Redirect("/PessoaJuridica/Index");
        }
    }
}
