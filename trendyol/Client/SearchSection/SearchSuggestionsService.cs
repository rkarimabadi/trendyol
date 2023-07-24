using System.Net.Http.Json;
using trendyol.Shared.Models;

namespace trendyol.Client.SearchSection
{
    public class SearchSuggestionsService : ISearchSuggestionsService
    {
        private HttpClient _httpClient;
        public SearchSuggestionsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GenericResponseModel<ICollection<SuggestionModel>>> Suggestions(string query)
        {
            return await _httpClient.GetFromJsonAsync<GenericResponseModel<ICollection<SuggestionModel>>>($"/api/SearchSuggestion/{query}");
        }
    }
}
