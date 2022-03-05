using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BancoRoxinho.Dominio.Services
{
    public class PessoaFisicaService
    {
        private ApplicationDBContext _context = new ApplicationDBContext();
        
        public void Adicionar(
            string nome,
            string sobrenome,
            int idade,
            string cpf,
            string endereco = "")
        {
            PessoaFisica pessoa = new PessoaFisica();

            pessoa.Nome = nome;
            pessoa.Sobrenome = sobrenome;
            pessoa.Idade = idade;
            pessoa.CPF = cpf;
            pessoa.Endereco = endereco;
            pessoa.ContaCorrente = new ContaCorrente();

            if (pessoa.MaiorIdade && pessoa.VerificarCPF(pessoa.CPF))
            {
                _context.PessoasFisicas.Add(pessoa);
                _context.SaveChanges();
            }
        }

        public List<PessoaFisica> ObterLista()
        {
            var resultado = _context.PessoasFisicas
                .Include(item => item.ContaCorrente).ToList();
            return resultado;
        }

        public PessoaFisica ObterPessoa(string cpf)
        {
            var pessoa = _context.PessoasFisicas.Where(item => item.CPF == cpf).ToList();
            return pessoa.First();
        }

        public void Editar(
            string cpf,
            string nome = "",
            string sobrenome = "",
            int idade = 0,
            string endereco = "")
        {

            foreach(var pessoa in PessoasRepository.PessoasFisicas)
            {
                if(pessoa.CPF == cpf)
                {
                    if (!string.IsNullOrEmpty(nome) && !string.IsNullOrWhiteSpace(nome))
                        pessoa.Nome = nome;

                    if (!string.IsNullOrWhiteSpace(endereco) && !string.IsNullOrEmpty(endereco))
                        pessoa.Endereco = endereco;

                    if (idade >= PessoaFisica.IdadeMinima)
                        pessoa.Idade = idade;

                    if (!string.IsNullOrWhiteSpace(sobrenome) && !string.IsNullOrEmpty(sobrenome))
                        pessoa.Sobrenome = sobrenome;
                }
            }

            // FINALIZAR A EDIÇÃO DE PESSOAS
        }

        public void Excluir(string cpf)
        {
            var pessoa = ObterPessoa(cpf);
            _context.PessoasFisicas.Remove(pessoa);
            _context.SaveChanges();
        }
    }
}
