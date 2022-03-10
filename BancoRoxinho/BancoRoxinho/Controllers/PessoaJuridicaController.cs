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

        [Route("/PessoaJuridica/{cpf}/Visualizar")]
        public ActionResult Visualizar([FromRoute] string cpf)
        {
            var pessoa = pessoaJuridicaService.ObterPessoa(cpf);
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
            if (string.IsNullOrEmpty(pessoa.CPF)) // Error 500
                return BadRequest("Não é possível adicionar uma pessoa sem CPF.");

            pessoaJuridicaService.Adicionar(pessoa);

            return Redirect("/PessoaJuridica/Index");
        }

        [HttpPost] //[HttpDelete]
        [Route("/PessoaJuridica/Deletar/{cpf}")]
        // localhost:5001/PessoaJuridica/Deletar/000.000.000-00
        public ActionResult Deletar([FromRoute] string cpf)
        {
            pessoaJuridicaService.Excluir(cpf);

            // nameof(Index) == "Index"
            // nameof(RedirectToAction) == "RedirectToAction"
            return RedirectToAction(nameof(Index));
        }


        [HttpDelete]
        [Route("/PessoaJuridica/{id}/Deletar")]
        // https://localhost:5001/PessoaJuridica/25/Deletar
        // https://www.sharerh.com/PessoaJuridica/25/Deletar
        public ActionResult Deletar([FromRoute] int id)
        {
            // pessoaJuridicaService.Excluir(id)
            return RedirectToAction(nameof(Index));
        }
    }
}
