using System.Collections.Generic;

namespace BancoRoxinho.Dominio.Model
{
    // public, private, package, internal
    public class ContaCorrente
    {
        public int NumeroDaConta;
        public float Saldo;
        public List<Transacoes> Extrato = new List<Transacoes>();

        public void TransferirSaldo(Pessoa credora, Pessoa destinatario, int valor)
        {


        }
    }
}
