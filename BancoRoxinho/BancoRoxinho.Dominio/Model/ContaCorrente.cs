using System.Collections.Generic;
using BancoRoxinho.Dominio.Dados;

namespace BancoRoxinho.Dominio.Model
{
    // public, private, package, internal
    // public, private, package, internal
    public class ContaCorrente
    {
        public int NumeroDaConta;
        public float Saldo;
        public List<Transacoes> Extrato = new List<Transacoes>();

        public ContaCorrente()
        {
            var listaDePessoas = PessoasRepository.PessoasFisicas;
            int numero = listaDePessoas.Count + 1;
            NumeroDaConta = numero;
        }

        public void TransferirSaldo(Pessoa credora, Pessoa destinatario, int valor)
        {


        }
    }
}
