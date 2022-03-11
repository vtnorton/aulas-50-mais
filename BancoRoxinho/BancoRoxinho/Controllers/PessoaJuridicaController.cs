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

        [HttpPost] //[HttpDelete]
        [Route("/PessoaJuridica/Deletar/{id}")]
        // localhost:5001/PessoaJuridica/Deletar/000.000.000-00
        public ActionResult Deletar([FromRoute] int id)
        {
            pessoaJuridicaService.ExcluirPeloId(id);

            // nameof(Index) == "Index"
            // nameof(RedirectToAction) == "RedirectToAction"
            return RedirectToAction(nameof(Index));
        }
               
    }
}
