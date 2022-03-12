using GatinhosFofinhos.Models;
using GatinhosFofinhos.Repository;
using Microsoft.Extensions.Configuration;

namespace GatinhosFofinhos.Servico
{
    public class MainService
    {
        private MainRepository _mainRepository;

        public MainService(IConfiguration configuration)
        {
            _mainRepository = new MainRepository(configuration);
        }

        public void Adicionar(Categoria categoria)
        {
            _mainRepository.InsertCategoria(categoria);
        }
    }
}
