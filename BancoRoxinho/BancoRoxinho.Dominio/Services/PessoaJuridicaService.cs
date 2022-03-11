using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoRoxinho.Dominio.Services
{
    public class PessoaJuridicaService
    {
        private ApplicationDBContext _contextPj = new ApplicationDBContext();


        public void Cadastrar(PessoaJuridica pessoaJ)

        {
             pessoaJ.ContaCorrente = new ContaCorrente();
            _contextPj.PessoasJuridicas.Add(pessoaJ);
            _contextPj.SaveChanges();



        }

        public PessoaJuridica ObterPessoa(string cnpj)
        {
            var pessoa = _contextPj.PessoasJuridicas.Where(item => item.CPNJ == cnpj).ToList();
            return pessoa.First();
        }

        public List<PessoaJuridica> ObterLista()
        {
            var resultado = _contextPj.PessoasJuridicas
                .OrderBy(item => item.CPNJ).ToList();
            return resultado;
        }

        public void ExcluirPJ(string cnpj)
        {

            var pessoa = ObterPessoa(cnpj);
            _contextPj.PessoasJuridicas.Remove(pessoa);
            _contextPj.SaveChanges(true);
        }

    }
}
