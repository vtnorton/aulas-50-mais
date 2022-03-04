using BancoRoxinho.Dominio.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BancoRoxinho.Dominio.Dados
{
    public class PessoasRepository
    {
        public readonly static string CONNECTIONSTRING = "Server=localhost\\SQLEXPRESS; Database=Aulas50Vitor;Integrated Security=SSPI";
        public static List<PessoaFisica> PessoasFisicas = new List<PessoaFisica>();
        public static List<PessoaJuridica> PessoaJuridicas = new List<PessoaJuridica>();


        public List<PessoaFisica> ObterPessoasFisicas()
        {
            var lista = new List<PessoaFisica>();

            var conexaoBancoDeDados = new SqlConnection(CONNECTIONSTRING);
            conexaoBancoDeDados.Open();

            var sqlCommand = new SqlCommand("SELECT * FROM PessoaFisica;", conexaoBancoDeDados);
            var resultado = sqlCommand.ExecuteReader();

            while (resultado.Read())
            {
                var pessoa = new PessoaFisica();
                pessoa.CPF = resultado["CPF"].ToString();
                pessoa.Nome = resultado["Nome"].ToString();
                pessoa.Idade = int.Parse(resultado["Idade"].ToString());
                pessoa.Sobrenome = resultado["Sobrenome"].ToString();
                pessoa.Endereco = resultado["Endereco"].ToString();

                lista.Add(pessoa);
            }

            conexaoBancoDeDados.Close();
            return lista;
        }

        public PessoaFisica ObterPessoaFisica(string cpf)
        {
            var pessoa = new PessoaFisica();
            var conexaoBancoDeDados = new SqlConnection(CONNECTIONSTRING);
            conexaoBancoDeDados.Open(); 

            var sqlCommand = new SqlCommand("SELECT * FROM PessoaFisica WHERE CPF = @cpf;", conexaoBancoDeDados);

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@cpf";
            parametro.Value = cpf;

            sqlCommand.Parameters.Add(parametro);

            var resultado = sqlCommand.ExecuteReader();

            while (resultado.Read())
            {
                pessoa.CPF = resultado["CPF"].ToString();
                pessoa.Nome = resultado["Nome"].ToString();
                pessoa.Idade = int.Parse(resultado["Idade"].ToString());
                pessoa.Sobrenome = resultado["Sobrenome"].ToString();
                pessoa.Endereco = resultado["Endereco"].ToString();
            }

            conexaoBancoDeDados.Close();
            return pessoa;
        }
    }
}
