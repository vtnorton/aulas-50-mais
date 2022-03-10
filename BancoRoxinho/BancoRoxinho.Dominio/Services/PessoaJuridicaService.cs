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
        private ApplicationDBContext _context = new ApplicationDBContext();
        public void Adicionar(PessoaJuridica pessoa)
        {
            if  (pessoa.VerificarCNPJ(pessoa.CNPJ))
            {
                if (!_context.PessoasJuridicas.Where(item => item.CNPJ== pessoa.CNPJ).Any())
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
                .OrderBy(item => item.RazaoSocial).ToList();
            return resultado;
        }


        public PessoaJuridica ObterPessoa(string cnpj)
        {
            var pessoa = _context.PessoasJuridicas
                .Where(item => item.CNPJ == cnpj)
                .Include(item => item.ContaCorrente).ToList();
            return pessoa.First();
        }

        public void Excluir(string cnpj)
        {
            var pessoa = ObterPessoa(cnpj);
            _context.PessoasJuridicas.Remove(pessoa);
            _context.SaveChanges();
        }

    }
}
