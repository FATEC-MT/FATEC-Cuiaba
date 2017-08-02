using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TokenManager.Services;

namespace Sample.Application.AppServices.SampleAppService
{
    public class SampleAppService
    {
        public readonly PrepararClient _prepararClient;
        public readonly HttpClient _httpClient;

        public SampleAppService(PrepararClient prepararClient)
        {
            _prepararClient = prepararClient;
            _httpClient = _prepararClient.ParaConsumirApi().Result;
        }

        public async Task<Sample> ConsultarPeloId(int idDoSample)
        {
            var respostaDaRequisicao = await _httpClient.GetAsync($"uri/{idDoSample}");
            return JsonConvert.DeserializeObject<Sample>(await respostaDaRequisicao.Content.ReadAsStringAsync());
        }
        public async Task<IEnumerable<Sample>> ConsultarTodasSamples()
        {
            var respostaDaRequisicao = await _httpClient.GetAsync($"uri/Samples");
            return JsonConvert.DeserializeObject<IEnumerable<Sample>>(await respostaDaRequisicao.Content.ReadAsStringAsync());
        }
        public async Task<string> NovaSample(Sample Sample)
        {
            var SampleJson = JsonConvert.SerializeObject(Sample);
            var conteudoDaResposta = await _httpClient.PostAsync($"uri/Samples", new StringContent(SampleJson, Encoding.UTF8, "application/json"));
            return conteudoDaResposta.StatusCode.ToString();
        }
        public async Task<string> EditarSample(Sample Sample)
        {
            var SampleJson = JsonConvert.SerializeObject(Sample);
            var respostaDaRequisicao = await _httpClient.PutAsync($"uri/Samples/{Sample.IdDaSample}", new StringContent(SampleJson, Encoding.UTF8, "application/json"));
            return respostaDaRequisicao.StatusCode.ToString();
        }
        public async Task<string> DeletarSample(int idDaSample)
        {
            var respostaDaRequisicao = await _httpClient.DeleteAsync($"uri/Samples/{idDaSample}");
            var conteudoDaResposta = await respostaDaRequisicao.Content.ReadAsStringAsync();
            return conteudoDaResposta.ToString();
        }
    }
}