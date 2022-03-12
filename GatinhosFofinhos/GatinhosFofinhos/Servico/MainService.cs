using GatinhosFofinhos.Models;
using GatinhosFofinhos.Models.ViewModels;
using GatinhosFofinhos.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatinhosFofinhos.Servico
{
    public class MainService
    {
        private MainRepository _mainRepository;
        private CatAPIService _catAPIService;

        public MainService(IConfiguration configuration)
        {
            _mainRepository = new MainRepository(configuration);
            _catAPIService = new CatAPIService(configuration);
        }

        public void Adicionar(Categoria categoria)
        {
            _mainRepository.InsertCategoria(categoria);
        }

        public List<Categoria> ObterLista()
        {
            var listaDeCategoria = _mainRepository.SelectCategorias();
            return listaDeCategoria;
        }

        public Categoria ObterCategoria(int id)
        {
            // EXERCÍCIO 01
            // Dono da empresa falou que o sistema tá muito lento 
            // e ai o arquiteto sugeriu uma alteração para deixar mais rápido.
            // O que você tem que fazer:
            // Obter Categoria filtrado direto do banco de dados
            var lista = ObterLista();
            var categoria = lista.Where(item => item.Id == id).First();
            return categoria;
        }

        public async Task<VisualizarViewModel> ObterVisualizacao(int idCategoria)
        {
            var visualizador = new VisualizarViewModel();

            var categoria = _mainRepository.SelectCategoria(idCategoria);
            visualizador.Categoria = categoria;

            var listaDeGatinhos = await _catAPIService.ObterGatosPorCategoria(categoria.IdCategoria);
            visualizador.Lista = listaDeGatinhos;

            return visualizador;
        }

        public void DeletarCategoria(int idDaCatagoria)
        {
            _mainRepository.DeleteCategoria(idDaCatagoria);
        }
    }
}
