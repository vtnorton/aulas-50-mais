using BancoRoxinho.Dominio.Model;
using BancoRoxinho.Dominio.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BancoRoxinho.Controllers
{
    public class PessoaFisicaController : Controller
    {
        PessoaFisicaService pessoaFisicaService = new PessoaFisicaService();
        //Action
        public IActionResult Index() 
        {
            var ListaObtida = pessoaFisicaService.ObterLista();
            return View(ListaObtida); 
        }

        [Route("/PessoaFisica/{cpf}/Visualizar")]
        public ActionResult Visualizar([FromRoute] string cpf)
        {
            var pessoa = pessoaFisicaService.ObterPessoa(cpf);
            return View(pessoa);    
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
                return BadRequest("Não foi possível adicionar valor nulo");

            pessoaFisicaService.Adicionar(pessoa);

            return Redirect("/PessoaFisica/Index");
        }

        [HttpPost] //[HttpDelete]
        [Route("/PessoaFisica/Deletar/{cpf}")]
        //  localhost:5001/PessoaFisica/Deletar/000.000.000-00

        public ActionResult Deletar([FromRoute] string cpf)
        {
            pessoaFisicaService.Excluir(cpf);

            // nameof(Index) == "Index"
            // nameof(RedirectToAction) == "RedirectToAction"
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        [Route("/PessoaFisica/{id}/Deletar")]
        //https://localhost:5001/PessoaFisica/25/Deletar
        //https://www.sharerh.com/PessoaFisica/25/Deletar

        public ActionResult Deletar([FromRoute] int id)
        {
            //pessoaFisicaService.Excluir(id)
            return RedirectToAction(nameof(Index));   
        }
    }
}
