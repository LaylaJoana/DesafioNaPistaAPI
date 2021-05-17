using Domain.Dtos;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra.CrossCutting.GatewayPagamento
{
    public class GatewayPagamento
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public GatewayPagamento(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient.CreateClient();
        }

        public async Task<PagamentoResponseDto> AutorizarPagamento(PagamentoRequestDto pagamentoRequest)
        {
            PagamentoResponseDto pagamentoDto = null;

            var appSettings = _configuration.GetSection("AppSettings");
            var url = appSettings["UrlGatewayPagamento"];

            var json = JsonSerializer.Serialize(pagamentoRequest);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(url, stringContent).ContinueWith(http =>
            {
                var result = http.Result.Content.ReadAsStringAsync().Result;
                pagamentoDto = JsonSerializer.Deserialize<PagamentoResponseDto>(result);
            });

            await response;
            return pagamentoDto;
        }
    }
}
