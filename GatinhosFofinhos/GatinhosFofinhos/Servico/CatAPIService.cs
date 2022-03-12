using GatinhosFofinhos.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GatinhosFofinhos.Servico
{
    public class CatAPIService
    {
        private HttpClient _httpClient;
        private readonly string _urlDaAPI;
        private readonly string _apiKey;

        public CatAPIService(IConfiguration configuration)
        {
            _urlDaAPI = configuration["TheAPICat:URL"].ToString();
            _apiKey = configuration["TheAPICat:Key"].ToString();

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
        }

        public async Task<List<CategoriasDaAPIDeGatos>> ObterLista()
        {
            var resposta = await _httpClient.GetAsync(_urlDaAPI + "categories");

            if(resposta.IsSuccessStatusCode)
            {
                var conteudoDaResposta = await resposta.Content.ReadAsStringAsync();
                var conversaoDoJson = JsonConvert.DeserializeObject<List<CategoriasDaAPIDeGatos>>(conteudoDaResposta);
                return conversaoDoJson;
            }

            return new List<CategoriasDaAPIDeGatos>();
        } 

        public async Task<List<FotosDeGatinhos>> ObterGatosPorCategoria(int idCategoria)
        {
            var resposta = await _httpClient.GetAsync($"{_urlDaAPI}images/search?limit=8&category_ids={idCategoria}");

            if (resposta.IsSuccessStatusCode)
            {

                var conteudoDaResposta = await resposta.Content.ReadAsStringAsync();
                var listaDeFotosDeGatinhos = JsonConvert.DeserializeObject<List<FotosDeGatinhos>>(conteudoDaResposta);
                return listaDeFotosDeGatinhos;
            }

            return new List<FotosDeGatinhos>();
        }
    }
}
