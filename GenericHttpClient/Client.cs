using System.Net.Http.Headers;
using System.Runtime;
using System.Net.Http;
using System.Text.Json;

namespace UseCase1.GenericHttpClient
{
    public class Client
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public Client(JsonSerializerOptions options)
        {
            _client = CreateHttpClient();
            _jsonOptions = options;
        }

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();

            return client;
        }

        public async Task<string> Get(string path)
        {
            var result = await _client.GetAsync(path);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<T?> Get<T>(string path)
        {
            var result = await _client.GetAsync(path);
            var json = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }
    }
}
