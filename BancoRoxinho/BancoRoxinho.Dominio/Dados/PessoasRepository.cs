using BancoRoxinho.Dominio.Model;
using System.Collections.Generic;

namespace BancoRoxinho.Dominio.Dados
{
    public class PessoasRepository
    {
        public static List<PessoaFisica> PessoasFisicas = new List<PessoaFisica>();
        public static List<PessoaJuridica> PessoaJuridicas = new List<PessoaJuridica>();
    }
}
