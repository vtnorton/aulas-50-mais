using GatinhosFofinhos.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace GatinhosFofinhos.Repository
{
    public class MainRepository
    {
        private SqlConnection _sqlConnection;
        private readonly string _tabelaCategoria = "tb_categorias";

        public MainRepository(IConfiguration configuration)
        {
            var stringConnection = configuration.GetConnectionString("Principal");
            _sqlConnection = new SqlConnection(stringConnection);
        }

        public void InsertCategoria(Categoria categoria)
        {
            var parametroDeNome = new SqlParameter()
            {
                ParameterName = "@nome",
                Value = categoria.Nome
            };

            var parametroDeDescricao = new SqlParameter()
            {
                ParameterName = "@descricao",
                Value = categoria.Descricao
            };

            var parametroDeIdCategoria = new SqlParameter()
            {
                ParameterName = "@idcategoria",
                Value = categoria.IdCategoria
            };

            string comando = $"INSERT INTO {_tabelaCategoria}" +
                $"(Nome, Descricao, IdCategoria) VALUES " +
                $"(@nome, @descricao, @idcategoria)";

            var sqlComando = new SqlCommand(comando, _sqlConnection);

            sqlComando.Parameters.Add(parametroDeNome);
            sqlComando.Parameters.Add(parametroDeDescricao);
            sqlComando.Parameters.Add(parametroDeIdCategoria);


            _sqlConnection.Open();

            sqlComando.ExecuteNonQuery();

            _sqlConnection.Close();


        }
    }
}
