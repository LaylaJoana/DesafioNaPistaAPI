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
        public GatewayPagamento(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PagamentoResponseDto> AutorizarPagamento(PagamentoRequestDto pagamentoRequest)
        {
            PagamentoResponseDto pagamentoDto = null;

            var appSettings = _configuration.GetSection("AppSettings");
            var url = appSettings["UrlGatewayPagamento"];

            var json = JsonSerializer.Serialize(pagamentoRequest);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var _httpClient = new HttpClient();
            var response = _httpClient.PostAsync(url, stringContent).ContinueWith(http =>
            {
                if (http.Status == TaskStatus.RanToCompletion)
                {
                    var result = http.Result.Content.ReadAsStringAsync().Result;
                    pagamentoDto = JsonSerializer.Deserialize<PagamentoResponseDto>(result,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            });

            await response;
            return pagamentoDto;
        }
    }
}
