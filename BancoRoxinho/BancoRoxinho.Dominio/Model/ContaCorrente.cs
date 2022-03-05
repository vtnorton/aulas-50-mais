using BancoRoxinho.Dominio.Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoRoxinho.Dominio.Model
{
    // public, private, package, internal
    public class ContaCorrente
    {
        [Key]
        public int Id { get; set; }
        public int NumeroDaConta { get; set; }
        public float Saldo { get; set; }

        [NotMapped]
        public List<Transacoes> Extrato { get; set; }

        public ContaCorrente()
        {
            var sorteador = new Random();
            int numero = sorteador.Next(0,9000);
            NumeroDaConta = numero;
        }

        public void TransferirSaldo(Pessoa credora, Pessoa destinatario, int valor)
        {


        }
    }
}
