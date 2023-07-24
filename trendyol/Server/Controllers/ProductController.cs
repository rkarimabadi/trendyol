using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using trendyol.Shared;
using trendyol.Shared.Models;

namespace trendyol.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ITranslator _translator;
        public ProductController(HttpClient httpClient, ITranslator translator)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://public.trendyol.com/discovery-web-searchgw-service/v2/api/infinite-scroll/sr");
            _translator = translator;
        }
        [HttpGet("{query}/{offset}")]
        public async Task<GenericResponseModel<ProductModel>> Get([FromRoute] string query, [FromRoute] int offset)
        {
            //var translatedQuery = await _translator.Translate(query);
            var result = await _httpClient.GetFromJsonAsync<GenericResponseModel<ProductModel>> ($"?q={query}&qt={query}&st={query}&os=1&sk=1&pi=3&culture=tr-TR&userGenderId=1&pId=0&isLegalRequirementConfirmed=false&searchStrategyType=DEFAULT&productStampType=TypeA&scoringAlgorithmId=2&fixSlotProductAdsIncluded=true&searchAbDecider=Suggestion_A,Relevancy_1,FilterRelevancy_1,ListingScoringAlgorithmId_1,Smartlisting_2,SuggestionBadges_B,ProductGroupTopPerformer_B,OpenFilterToggle_2,SuggestionStoreAds_A,BadgeBoost_A,RF_1&initialSearchText={query}&offset={offset}");
            if (result != null && result.IsSuccess && result.Result != null)
            {
                result.Result.Products = await Task.WhenAll(result.Result.Products.Select(async s => { 
                    s.name = await _translator.Translate(s.name, "tr", "fa");
                    return s; 
                }));
            }
            return result;
        }
    }
}

