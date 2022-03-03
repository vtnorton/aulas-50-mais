using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System.Collections.Generic;
using CPFCNPJ;
using System.Linq;
using System;


namespace BancoRoxinho.Dominio.Services
{
    public class PessoaJuridicaService
    {
        public void Adicionar(
            string nomePJ,
            string sobrenomePJ,
            string razaoSocialPJ,
            string cnpj,
            string enderecoPJ = ""
            )
        {
            PessoaJuridica pessoa = new PessoaJuridica();

            bool VerificarCNPJ(string cnpjASerValdido)
            {
                var verificador = new Main();
                var cnpjValido = verificador.IsValidCPFCNPJ(cnpjASerValdido);
                return cnpjValido;
            }

            List<PessoaJuridica> listaDePessoas;
            listaDePessoas = PessoasRepository.PessoasJuridicas;

            pessoa.NomePJ = nomePJ;
            pessoa.SobrenomePJ = sobrenomePJ;
            pessoa.RazaoSocialPJ = razaoSocialPJ;
            pessoa.CNPJ = cnpj;
            pessoa.EnderecoPJ = enderecoPJ;

            if (VerificarCNPJ(pessoa.CNPJ))
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

    }
}