using MVCBiblioteca.Helpers;
using MVCBiblioteca.Models;

namespace MVCBiblioteca.Services
{
    public class BibliotecaAPIService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/find";

        public BibliotecaAPIService(HttpClient client ) { 
            this._client = client;
        }

        public async Task<IEnumerable<Biblioteca>> Find() {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<Biblioteca>>(); ;
        }
    }
}
