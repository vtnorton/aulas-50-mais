using GatinhosFofinhos.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
            string comando = $"INSERT INTO {_tabelaCategoria}" +
                $"(Nome, Descricao, IdCategoria) VALUES " +
                $"(@nome, @descricao, @idcategoria)";

            var sqlComando = new SqlCommand(comando, _sqlConnection);

            sqlComando.AdicionarParametrosDaCategoria(
                categoria.IdCategoria,
                categoria.Nome,
                categoria.Descricao);

            _sqlConnection.Open();

            sqlComando.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public List<Categoria> SelectCategorias()
        {
            string comando = $"SELECT * FROM {_tabelaCategoria}";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);
            List<Categoria> categorias = new List<Categoria>();

            _sqlConnection.Open();

            var resultado = sqlCommand.ExecuteReader();

            while (resultado.Read())
            {
                var categoria = new Categoria()
                {
                    Id = (int)resultado["Id"],
                    Nome = resultado["Nome"].ToString(),
                    Descricao = resultado["Descricao"].ToString(),
                    IdCategoria = (int)resultado["IdCategoria"]
                };

                categorias.Add(categoria);
            }

            _sqlConnection.Close();

            return categorias;
        }

        public Categoria SelectCategoria(int idCategoria)
        {
            Categoria categoria = new Categoria();
            string comando = $"SELECT * FROM {_tabelaCategoria} WHERE Id = @id";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);
            var parametro = new SqlParameter()
            {
                ParameterName = "@id",
                Value = idCategoria
            };
            sqlCommand.Parameters.Add(parametro);

            _sqlConnection.Open();

            var resultado = sqlCommand.ExecuteReader();
            while (resultado.Read())
            {
                categoria.Id = (int)resultado["Id"];
                categoria.Nome = (string)resultado["Nome"];
                categoria.IdCategoria = (int)resultado["IdCategoria"];
                categoria.Descricao = resultado["Descricao"].ToString();
            }

            _sqlConnection.Close();

            return categoria;
        }

        public void UpdateCategoria(Categoria categoria, int idDaCategoria)
        {
            var comando = 
                $@"UPDATE {_tabelaCategoria} 
                   SET Nome = @nome,
                       Descricao = @descricao,
                       IdCategoria = @idcategoria
                   WHERE Id = @id";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);

            sqlCommand.AdicionarParametrosDaCategoria(
                categoria.IdCategoria,
                categoria.Nome,
                categoria.Descricao);

            var parametro = new SqlParameter()
            {
                ParameterName = "@id",
                Value = idDaCategoria
            };

            sqlCommand.Parameters.Add(parametro);

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void DeleteCategoria(int idCategoria)
        {
            var comando = $"DELETE FROM {_tabelaCategoria} WHERE Id = @id";
            var sqlCommand = new SqlCommand(comando, _sqlConnection);
            var parametro = new SqlParameter()
            {
                ParameterName = "@id",
                Value = idCategoria
            };

            sqlCommand.Parameters.Add(parametro);

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }


    public static class Helper
    {
        public static SqlCommand AdicionarParametrosDaCategoria(
            this SqlCommand comando,
            int idCategoria,
            string nome,
            string descricao)
        {
            var parametroDeNome = new SqlParameter()
            {
                ParameterName = "@nome",
                Value = nome
            };

            var parametroDeDescricao = new SqlParameter()
            {
                ParameterName = "@descricao"
            };

            if (descricao != null)
                parametroDeDescricao.Value = descricao;
            else
                parametroDeDescricao.Value = DBNull.Value;

            var parametroDeIdCategoria = new SqlParameter()
            {
                ParameterName = "@idcategoria",
                Value = idCategoria
            };

            comando.Parameters.Add(parametroDeNome);
            comando.Parameters.Add(parametroDeDescricao);
            comando.Parameters.Add(parametroDeIdCategoria);

            return comando;
        }
    }
}
