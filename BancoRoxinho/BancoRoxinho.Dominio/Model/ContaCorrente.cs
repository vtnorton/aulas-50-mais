<<<<<<< HEAD
﻿using System.Collections.Generic;
using BancoRoxinho.Dominio.Dados;
=======
﻿using BancoRoxinho.Dominio.Dados;
using System.Collections.Generic;
>>>>>>> a0ae49a8e7eb863540cc24ea553552ebb6e6fae2

namespace BancoRoxinho.Dominio.Model
{
    // public, private, package, internal
<<<<<<< HEAD
    // public, private, package, internal
=======
>>>>>>> a0ae49a8e7eb863540cc24ea553552ebb6e6fae2
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
