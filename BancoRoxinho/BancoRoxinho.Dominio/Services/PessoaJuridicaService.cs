using System.Collections.Generic;
using System.Linq;
using BancoRoxinho.Dominio.Dados;
using BancoRoxinho.Dominio.Model;

namespace BancoRoxinho.Dominio.Service
{
    public class PessoaJuridicaService 
    {
        public void Adicionar(string razaosocial, string cnpj, string endereco = "")

        {
            PessoaJuridica pessoaJuridica = new PessoaJuridica();

            List<PessoaJuridica> listaPessoaJuridicas;
            listaPessoaJuridicas = PessoasRepository.PessoaJuridicas;

            pessoaJuridica.RazaoSocial = razaosocial;
            pessoaJuridica.CNPJ = cnpj;
            pessoaJuridica.Endereco = endereco;

            if (pessoaJuridica.VerificarCNPJ(pessoaJuridica.CNPJ)) 
            {
                listaPessoaJuridicas.Add(pessoaJuridica);
            }
        }

        public List<PessoaJuridica> ObterLista()
        {
            return PessoasRepository.PessoaJuridicas;
        }

        public PessoaJuridica ObterPessoaJuridica(string cnpj)
        {
            PessoaJuridica pessoaJuridicaCadastrada;
            List<PessoaJuridica> listaPessoasJuridicas = PessoasRepository.PessoaJuridicas;
                                                 // Lambda Expressions  
            var listaFiltrada = listaPessoasJuridicas.Where(item => item.CNPJ == cnpj);
            pessoaJuridicaCadastrada = listaFiltrada.First();

            return pessoaJuridicaCadastrada;
        }

        public void Editar(
            string razaosocial,
            string cnpj,
            string endereco = ""
            )

        {

            foreach (var pessoaJuridica in PessoasRepository.PessoaJuridicas)
            {
                if (pessoaJuridica.CNPJ == cnpj) 
                {
                    if (!string.IsNullOrEmpty(razaosocial) && !string.IsNullOrWhiteSpace(razaosocial))
                        pessoaJuridica.RazaoSocial = razaosocial;

                    if (!string.IsNullOrWhiteSpace(cnpj) && !string.IsNullOrEmpty(cnpj))
                        pessoaJuridica.CNPJ = cnpj;

                    if (!string.IsNullOrWhiteSpace(endereco) && !string.IsNullOrEmpty(endereco))
                        pessoaJuridica.Endereco = endereco;

                }
            }

            // FINALIZAR A EDIÇÃO DE PESSOAS
        }

        public void Excluir(string cnpj)
        {
            var pessoaJuridica = ObterPessoaJuridica (cnpj);
            PessoasRepository.PessoaJuridicas.Remove(pessoaJuridica);
        }
    }
}
