using GatinhosFofinhos.Models;
using GatinhosFofinhos.Models.ViewModels;
using GatinhosFofinhos.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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

        public VisualizarViewModel ObterVisualizacao(int idCategoria)
        {
            var visualizador = new VisualizarViewModel();

            var categoria = _mainRepository.SelectCategoria(idCategoria);
            visualizador.Categoria = categoria;

            var listaDeGatinhos = _catAPIService.ObterGatosPorCategoria(categoria.IdCategoria);
            visualizador.Lista = listaDeGatinhos;

            return visualizador;
        }
    }
}
