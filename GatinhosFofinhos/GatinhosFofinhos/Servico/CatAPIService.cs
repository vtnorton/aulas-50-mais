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
        private readonly string urlDaAPI;
        private readonly string apiKey;
        public CatAPIService(IConfiguration configuration)
        {
            urlDaAPI = configuration["TheAPICat:URL"].ToString();
            apiKey = configuration["TheAPICat:Key"].ToString();
        }

        public async Task<List<CategoriasDaAPIDeGatos>> ObterLista()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            var resposta = await client.GetAsync(urlDaAPI + "categories");

            if(resposta.IsSuccessStatusCode)
            {
                var conteudoDaResposta = await resposta.Content.ReadAsStringAsync();
                var conversaoDoJson = JsonConvert.DeserializeObject<List<CategoriasDaAPIDeGatos>>(conteudoDaResposta);
                return conversaoDoJson;
            }

            return new List<CategoriasDaAPIDeGatos>();
        } 
    }
}
