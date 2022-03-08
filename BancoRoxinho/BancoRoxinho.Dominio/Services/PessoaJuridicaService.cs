using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BancoRoxinho.Dominio.Services
{
    public class PessoaJuridicaService
    {
        private ApplicationDBContext _context = new ApplicationDBContext();
        
        public void Adicionar(PessoaJuridica pessoa)
        {
            pessoa.ContaCorrente = new ContaCorrente();

            if (pessoa.VerificarCNPJ(pessoa.CNPJ))
            {
                if (!_context.PessoasJuridicas.Where(item => item.CNPJ == pessoa.CNPJ).Any())
                {
                    _context.PessoasJuridicas.Add(pessoa);
                    _context.SaveChanges();
                }
            }

        }

        public List<PessoaJuridica> ObterLista()
        {
            var resultado = _context.PessoasJuridicas
                 .Include(item => item.ContaCorrente)
                 .OrderBy(item => item.NomeFantasia).ToList();
            return resultado;
        }

        public PessoaJuridica ObterPessoa(string cnpj)
        {
            var pessoa = _context.PessoasJuridicas.Where(item => item.CNPJ == cnpj).ToList();
            return pessoa.First();
        }

        public void Editar(
            string cnpj,
            string nomeFantasia = "",
            string razaoSocial = "",
            string endereco = "")
        {

            foreach(var pessoa in _context.PessoasJuridicas)
            {
                if(pessoa.CNPJ == cnpj)
                {
                    if (!string.IsNullOrEmpty(nomeFantasia) && !string.IsNullOrWhiteSpace(nomeFantasia))
                        pessoa.NomeFantasia = nomeFantasia;

                    if (!string.IsNullOrWhiteSpace(razaoSocial) && !string.IsNullOrEmpty(razaoSocial))
                        pessoa.RazaoSocial = razaoSocial;

                    if (!string.IsNullOrWhiteSpace(endereco) && !string.IsNullOrEmpty(endereco))
                        pessoa.Endereco = endereco;

                }
            }
        }

        public void Excluir(string cnpj)
        {
            var pessoa = ObterPessoa(cnpj);
            _context.PessoasJuridicas.Remove(pessoa);
            _context.SaveChanges();
        }
    }
}
