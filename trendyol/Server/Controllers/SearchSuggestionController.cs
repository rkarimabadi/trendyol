using Microsoft.AspNetCore.Mvc;
using trendyol.Shared;
using trendyol.Shared.Models;

namespace trendyol.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchSuggestionController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ITranslator _translator;
        public SearchSuggestionController(HttpClient httpClient, ITranslator translator)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://public-mdc.trendyol.com/discovery-search-websfxsuggestions-santral/api/suggestions");
            _translator = translator;
        }
        [HttpGet("{query}")]
        public async Task<GenericResponseModel<ICollection<SuggestionModel>>> Get([FromRoute]string query)
        {
            var translatedQuery = await _translator.Translate(query);
            var result = await _httpClient.GetFromJsonAsync<GenericResponseModel<ICollection<SuggestionModel>>>($"?culture=tr-TR&text={translatedQuery}&searchTestParameter=&platform=WEB");
            if (result != null && result.IsSuccess && result.Result != null)
            {
                result.Result = await Task.WhenAll(result.Result.Select(async s => { s.persiantext = await _translator.Translate(s.text, "tr", "fa"); return s; }));
            }
            return result;
        }
    }
}