using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BancoRoxinho.Dominio.Services
{
    public class PessoaJuridicaService
    {
        public void Adicionar(
            string nomePJ,
            string sobrenomePJ,
            string razaosocialPJ,
            int idadePJ,
            string cnpj,
            string enderecoPJ = ""
            )
        {
            PessoaJuridica pessoa = new PessoaJuridica();

            List<PessoaJuridica> listaDePessoas;
            listaDePessoas = PessoasRepository.PessoasJuridicas;

            pessoa.NomePJ = nomePJ;
            pessoa.SobrenomePJ = sobrenomePJ;
            pessoa.RazaoSocialPJ = razaosocialPJ;
            pessoa.IdadePJ = idadePJ;
            pessoa.CNPJ = cnpj;
            pessoa.Endereco = enderecoPJ;

            if (pessoa.MaiorIdade && pessoa.VerificarCNPJ(pessoa.CNPJ))
            {
                listaDePessoas.Add(pessoa);
            }
        }

        public List<PessoaJuridica> ObterLista()
        {
            return PessoasRepository.PessoasJuridicas;
        }

        public PessoaJuridica ObterPessoa(string cnpj)
        {
            PessoaJuridica pessoaEncontrada;
            List<PessoaJuridica> listaDePessoas = PessoasRepository.PessoasJuridicas;
            // Lambda Expressions  
            var listaFiltrada = listaDePessoas.Where(item => item.CNPJ == cnpj);
            pessoaEncontrada = listaFiltrada.First();

            Console.WriteLine(listaDePessoas);
            return pessoaEncontrada;

        }

        public void Editar(
            string cnpj,
            string nomePJ = "",
            string sobrenomePJ = "",
            string razaosocialPJ = "",
            int idadePJ = 0,            
            string enderecoPJ = ""            
            )
        {
            List<PessoaJuridica> listaDePessoas;
            listaDePessoas = PessoasRepository.PessoasJuridicas;

            foreach (var pessoa in PessoasRepository.PessoasJuridicas)
            {
                if (pessoa.CNPJ == cnpj)
                {
                    if (!string.IsNullOrEmpty(nomePJ) && !string.IsNullOrWhiteSpace(nomePJ))
                        pessoa.NomePJ = nomePJ;

                    if (!string.IsNullOrWhiteSpace(enderecoPJ) && !string.IsNullOrEmpty(enderecoPJ))
                        pessoa.Endereco = enderecoPJ;

                    if (idadePJ >= PessoaFisica.IdadeMinima)
                        pessoa.IdadePJ = idadePJ;

                    if (!string.IsNullOrWhiteSpace(sobrenomePJ) && !string.IsNullOrEmpty(sobrenomePJ))
                        pessoa.SobrenomePJ = sobrenomePJ;

                    if (!string.IsNullOrWhiteSpace(razaosocialPJ) && !string.IsNullOrEmpty(razaosocialPJ))
                        pessoa.RazaoSocialPJ = razaosocialPJ;
                }

                listaDePessoas.Add(pessoa);
            }
        }

        public void Excluir(string cnpj)
        {
            var pessoa = ObterPessoa(cnpj);
            PessoasRepository.PessoasJuridicas.Remove(pessoa);
        }
    }
}