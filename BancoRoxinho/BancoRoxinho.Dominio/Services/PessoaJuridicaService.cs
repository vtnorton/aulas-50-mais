using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BancoRoxinho.Dominio.Services
{
    public class PessoaJuridicaService
    {
        private ApplicationDBContext _Context = new ApplicationDBContext();

        public void Adicionar(
            string razaosocial,
            string cnpj,
            string endereco = "")
        {
        
            PessoaJuridica pessoa = new PessoaJuridica();

            pessoa.RazaoSocial = razaosocial;
            pessoa.CNPJ = cnpj;
            pessoa.Endereco = endereco;
            pessoa.ContaCorrente = new ContaCorrente();

            if (pessoa.VerificarCNPJ(pessoa.CNPJ))
            {
                _Context.PessoasJuridicas.Add(pessoa);
                _Context.SaveChanges();
            }
        }

        public List<PessoaJuridica> ObterLista()
        {
            var resultado = _Context.PessoasJuridicas 
                .Include(item => item.ContaCorrente).ToList();
            return resultado;
        }

        public PessoaJuridica ObterPessoa(string cnpj)
        {
            var pessoa = _Context.PessoasJuridicas.Where(item => item.CNPJ == cnpj).ToList();
            return pessoa.First();
        }

        public void Editar(
            string cnpj,
            string razaosocial = "",
            string endereco = "")
        {

            foreach (var pessoa in _Context.PessoasJuridicas)
            {
                if (pessoa.CNPJ == cnpj)
                {
                    if (!string.IsNullOrEmpty(razaosocial) && !string.IsNullOrWhiteSpace(razaosocial))
                        pessoa.RazaoSocial = razaosocial;

                    if (!string.IsNullOrWhiteSpace(endereco) && !string.IsNullOrEmpty(endereco))
                        pessoa.Endereco = endereco;
                }
            }

            _Context.SaveChanges();

        }
        public void Excluir(string cnpj)
        {
            var pessoa = ObterPessoa(cnpj);
            _Context.PessoasJuridicas.Remove(pessoa);

            _Context.SaveChanges();

        }
    }
}
