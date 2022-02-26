using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;
using System.Collections.Generic;
using System.Linq;

namespace BancoRoxinho.Dominio.Services
{
    public class PessoaFisicaService
    {
        public void Adicionar(
            string nome,
            int idade,
            string cpf,
            string endereco = ""
            )
        {
            PessoaFisica pessoa = new PessoaFisica();

            List<PessoaFisica> listaDePessoas;
            listaDePessoas = PessoasRepository.PessoasFisicas;

            pessoa.Nome = nome;
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

            return pessoaEncontrada;
        }

        public void Editar(
            string cpf,
            string nome = "",
            string sobrenome ="",
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
                }
            }

            // FINALIZAR A EDIÇÃO DE PESSOAS
        }

        public void Excluir(string cpf)
        {
            var pessoa = ObterPessoa(cpf);
            PessoasRepository.PessoasFisicas.Remove(pessoa);
        }
    }
}
