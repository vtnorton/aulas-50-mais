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
            pessoaJuridicaService.Adicionar(pessoa);
            return Redirect("/PessoaJuridica/Index");

        }
        [Route("/PessoaJuridica/{cnpj}/Visualizar")]
        public ActionResult Visualizar([FromRoute] string cnpj)
        {
            var pessoa = pessoaJuridicaService.ObterPessoa(cnpj);
            return View(pessoa);
        }
        [HttpPost] //[HttpDelete]
        [Route("/PessoaJuridica/Deletar/{cnpj}")]
  
        public ActionResult Deletar([FromRoute] string cnpj)
        {
            pessoaJuridicaService.Excluir(cnpj);

            // nameof(Index) == "Index"
            // nameof(RedirectToAction) == "RedirectToAction"
            return RedirectToAction(nameof(Index));
        }
    }
}
