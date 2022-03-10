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

       

        public List<PessoaJuridica> ObterLista()
        {
            var resultado = _contextPj.PessoasJuridicas
                .OrderBy(item => item.CPNJ).ToList();
            return resultado;
        }

    }
}
