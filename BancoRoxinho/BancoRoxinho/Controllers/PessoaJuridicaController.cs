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

        [Route("/PessoaJuridica/{id}/Visualizar")]
        public ActionResult Visualizar([FromRoute] int id)
        {
            var pessoa = pessoaJuridicaService.ObterPessoaPeloId(id);
            return View(pessoa);
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
                return BadRequest("Não é possível adicionar empresa sem CNPJ.");

            pessoaJuridicaService.AdicionarPJ(pessoa);

            return Redirect("/PessoaJuridica/Index");
        }

        [HttpPost]
        [Route("/PessoaJuridica/Deletar/{id}")]
        public ActionResult Deletar([FromRoute] int id)
        {
            pessoaJuridicaService.ExcluirPeloId(id);

            return RedirectToAction(nameof(Index));
        }
               
    }
}
