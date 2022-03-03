using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BancoRoxinho.Dominio.Services
{
    public class PessoaFisicaService
    {
        public void Adicionar(
            string nome,
            string sobrenome,
            int idade,
            string cpf,
            string endereco = ""
            )
        {
            PessoaFisica pessoa = new PessoaFisica();

            List<PessoaFisica> listaDePessoas;
            listaDePessoas = PessoasRepository.PessoasFisicas;

            pessoa.Nome = nome;
            pessoa.Sobrenome = sobrenome;
            pessoa.Idade = idade;
            pessoa.CPF = cpf;
            pessoa.Endereco = endereco; 

            if (pessoa.MaiorIdade && pessoa.VerificarCPF(pessoa.CPF))
            {
                listaDePessoas.Add(pessoa);
            }
        }

        public List<PessoaFisica> ObterLista()
        {
            return PessoasRepository.PessoasFisicas;
        }

        public PessoaFisica ObterPessoa(string cpf)
        {
            PessoaFisica pessoaEncontrada;
            List<PessoaFisica> listaDePessoas = PessoasRepository.PessoasFisicas;
                                                            // Lambda Expressions  
            var listaFiltrada = listaDePessoas.Where(item => item.CPF == cpf);
            pessoaEncontrada = listaFiltrada.First();

            Console.WriteLine(listaDePessoas);
            return pessoaEncontrada;                  
               
        }

        public void Editar(
            string cpf,
            string nome = "",
            string sobrenome = "",
            int idade = 0,
            string endereco = "")
        {
            List<PessoaFisica> listaDePessoas;
            listaDePessoas = PessoasRepository.PessoasFisicas;

            foreach (var pessoa in PessoasRepository.PessoasFisicas)
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

            listaDePessoas.Add(pessoa);
            }                        
        }

        public void Excluir(string cpf)
        {
            var pessoa = ObterPessoa(cpf);
            PessoasRepository.PessoasFisicas.Remove(pessoa);
        }
    }
}
