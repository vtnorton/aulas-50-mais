using CPFCNPJ;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace BancoRoxinho.Dominio.Model
{
    // Pessoa Juridica herda Pessoa
    public class PessoaJuridica : Pessoa
    {
        public string CPNJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }


        public bool  VerificarCNPJ(string cnpj)
        {
            var verificador = new Main();
            return  verificador.IsValidCPFCNPJ(cnpj);
            
        }
    }
}
