using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System.Collections.Generic;
using System.Linq;

namespace BancoRoxinho.Dominio.Services
{
    internal class PessoaJuridicaService
    {
        public void Adicionar(
         string nome,
         string nomeFantasia,
         string cnpj,
         string endereco = ""
         )
        {
            PessoaJuridica pessoaJuridica = new PessoaJuridica();

            List<PessoaJuridica> listaDePessoasJuridicas;
            listaDePessoasJuridicas = PessoasRepository.PessoaJuridicas;

            pessoaJuridica.Nome = nome;
            pessoaJuridica.NomeFantasia = nomeFantasia;
            pessoaJuridica.CNPJ = cnpj;
            pessoaJuridica.Endereco = endereco;

            if (pessoaJuridica.VerificarCNPJ(pessoaJuridica.CNPJ))
            {
                listaDePessoasJuridicas.Add(pessoaJuridica);
            }
        }

        public PessoaJuridica ObterEmpresa(string cnpj)
        {
            PessoaJuridica empresaEncontrada;
            List<PessoaJuridica> listaDePessoas = PessoasRepository.PessoaJuridicas;
            // Lambda Expressions  
            var listaFiltrada = listaDePessoas.Where(item => item.CNPJ == cnpj);
            empresaEncontrada = listaFiltrada.First();

            return empresaEncontrada;
        }

        public void Editar(
           string cnpj,
           string nome = "",
           string nomeFantasia = "",
           string endereco = "")
        {

            foreach (var pessoaJuridica in PessoasRepository.PessoaJuridicas)
            {
                if (pessoaJuridica.CNPJ == cnpj)
                {
                    if (!string.IsNullOrEmpty(nome) && !string.IsNullOrWhiteSpace(nome))
                        pessoaJuridica.Nome = nome;

                    if (!string.IsNullOrEmpty(nomeFantasia) && !string.IsNullOrWhiteSpace(nomeFantasia))
                    pessoaJuridica.NomeFantasia = nomeFantasia;

                    if (!string.IsNullOrWhiteSpace(endereco) && !string.IsNullOrEmpty(endereco))
                        pessoaJuridica.Endereco = endereco;

                }
            } 
        }

        public void Excluir(string cnpj)
        {
            var pessoaJuridica = ObterEmpresa(cnpj);
            PessoasRepository.PessoaJuridicas.Remove(pessoaJuridica);
        }

    }
}
