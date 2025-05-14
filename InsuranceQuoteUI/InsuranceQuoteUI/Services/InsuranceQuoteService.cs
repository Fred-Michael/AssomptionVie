using InsuranceQuoteUI.Models;
using InsuranceQuoteUI.Utilities;
using System.Net.Http.Json;

namespace InsuranceQuoteUI.Services
{
    public class InsuranceQuoteService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = BackendConnection.API_URL;

        public InsuranceQuoteService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Guid?> SubmitQuoteAsync(QuoteRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Quotes", request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<QuoteIdResponse>();
            return content?.QuoteId;
        }

        public async Task<QuoteResponse?> GetQuoteAsync(Guid? quoteId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Quotes/{quoteId}");
            response.EnsureSuccessStatusCode();

            var quote = await response.Content.ReadFromJsonAsync<QuoteResponse>();
            return quote;
        }
    }
}
