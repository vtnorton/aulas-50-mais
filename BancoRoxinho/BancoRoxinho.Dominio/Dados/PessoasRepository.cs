using BancoRoxinho.Dominio.Model;
using System.Collections.Generic;

namespace BancoRoxinho.Dominio.Dados
{
    public class PessoasRepository
    {
        public List<PessoaFisica> PessoasFisicas = new List<PessoaFisica>();
        public List<PessoaJuridica> PessoaJuridicas = new List<PessoaJuridica>();
    }
}
