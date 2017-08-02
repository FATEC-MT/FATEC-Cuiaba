using System.Net.Http;
using System.Threading.Tasks;

namespace TokenManager.Services
{
    public class PrepararClient
    {
        public HttpClient _httpClient { get; private set; }
        public AdicionarHeader _adicionarHeader { get; private set; }

        public PrepararClient(HttpClient httpClient, AdicionarHeader adicionarHeader)
        {
            _httpClient = httpClient;
            _adicionarHeader = adicionarHeader;
        }

        public async Task<HttpClient> ParaConsumirApi()
        {
            var token = await _adicionarHeader.TokenDeAutorizacao();

            if((_httpClient.DefaultRequestHeaders.Authorization == null) || (token.IsExpired())) 
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {token.access_token}");
            }
            
            return _httpClient;
        }
    }
}