using System.Collections.Generic;

namespace BancoRoxinho.Dominio.Model
{
    // public, private, package, internal
<<<<<<< HEAD
    public class ContaCorrente 
=======
    public class ContaCorrente
>>>>>>> c35510f7e0b524b8ee26d6f625b7bba17a1a820b
    {
        public int NumeroDaConta;
        public float Saldo;
        public List<Transacoes> Extrato = new List<Transacoes>();

        public void TransferirSaldo(Pessoa credora, Pessoa destinatario, int valor)
        {


        }
    }
}
