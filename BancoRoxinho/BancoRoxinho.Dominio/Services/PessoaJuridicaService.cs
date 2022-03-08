using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
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



    }
}
