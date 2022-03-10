using BancoRoxinho.Dominio.Model;
using BancoRoxinho.Dominio.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BancoRoxinho.Controllers
{
    public class PessoaJuridicaController : Controller
    {
        PessoaJuridicaService pessoaJuridicaService = new PessoaJuridicaService();
        //Action
        public IActionResult Index()
        {
            var ListaObtida = pessoaJuridicaService.ObterLista(); 
            return View(ListaObtida);
        }

        [Route("/PessoaJuridica/{id}/Visualizar")]
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
            if (string.IsNullOrEmpty(pessoa.CNPJ)) // Error 500
                return BadRequest("Não foi possível adicionar valor nulo");

            pessoaJuridicaService.Adicionar();

            return Redirect("/PessoaJuridica/Index");
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

        [HttpDelete]
        [Route("/PessoaJuridica/{id}/Deletar")]

        public ActionResult Deletar([FromRoute] int id)
        {
            //pessoaFisicaService.Excluir(id)
            return RedirectToAction(nameof(Index));
        }
    }
}
