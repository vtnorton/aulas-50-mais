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

        public void AdicionarPJ(PessoaJuridica pessoa)
        {
            pessoa.ContaCorrente = new ContaCorrente();

            if (pessoa.VerificaCNPJ(pessoa.CNPJ))
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
                .OrderBy(item => item.Nome).ToList();
            return resultado;
        }
                
        public PessoaJuridica ObterPessoa(string cnpj)
        {
            var pessoa = _context.PessoasJuridicas
                .Where(item => item.CNPJ == cnpj)
                .Include(item => item.ContaCorrente).ToList();

            if (pessoa.Count() > 0)
            {
                return pessoa.First();
            }

            return null;

        }

        public void Excluir(string cnpj)
        {
            var pessoa = ObterPessoa(cnpj);
            if (pessoa != null)
            {
                _context.PessoasJuridicas.Remove(pessoa);
                _context.SaveChanges();
            }
           
        }


        public void Editar(
                     string cnpj,
                     string nome = "",
                     string endereco = "")
        {

            var entity = _context.PessoasJuridicas.First(item => item.CNPJ == cnpj);

            if (entity != null)
            {
                entity.Nome = nome;
                entity.Endereco = endereco;
                _context.SaveChanges();
            }
        }            
    }
}
