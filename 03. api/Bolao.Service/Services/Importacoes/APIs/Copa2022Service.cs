using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Importacoes.APIs
{
    public class Copa2022Service
    {
        private readonly RestClient _restClient;
        private readonly string _token;

        public Copa2022Service()
        {
            _restClient = new RestClient(new Uri($"{"http://api.cup2022.ir/api/v1"}"));

            _token = GetToken();
        }

        private string GetToken()
        {
            var jsonBody = new
            {
                Email = "rodrigo.zanferrari@gmail.com",
                Password = "q1w2e3r4t5"
            };

            var restRequest = new RestRequest("/user/login", Method.Post)
                .AddJsonBody(jsonBody);

            var restResponse = _restClient.Execute(restRequest);

            if (restResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Erro ao realizar autenticação na API: {restResponse.Content}");

            var result = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);

            return result.data.token;
        }

        public async Task<List<dynamic>> GetTimesAsync()
        {
            var restRequest = new RestRequest("/team", Method.Get)
                .AddHeader("Authorization", $"Bearer {_token}");

            var restResponse = await _restClient.ExecuteAsync<dynamic>(restRequest);

            if (restResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Erro ao consultar dados na API: {restResponse.Content}");

            var result = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);

            var lista = ((IEnumerable)result.data).Cast<dynamic>().ToList();

            return lista;
        }

        public async Task<List<dynamic>> GetPartidasAsync()
        {
            var restRequest = new RestRequest("/match", Method.Get)
                .AddHeader("Authorization", $"Bearer {_token}");

            var restResponse = await _restClient.ExecuteAsync<dynamic>(restRequest);

            if (restResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Erro ao consultar dados na API: {restResponse.Content}");

            var result = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);

            var lista = ((IEnumerable)result.data).Cast<dynamic>().ToList();

            return lista;
        }
    }
}
