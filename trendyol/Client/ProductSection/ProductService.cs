using System.Net.Http.Json;
using trendyol.Shared.Models;

namespace trendyol.Client.ProductSection
{
    public class ProductService : IProductService
    {
        private HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GenericResponseModel<ProductModel>> Products(string query, int offset)
        {
            return await _httpClient.GetFromJsonAsync<GenericResponseModel<ProductModel>>($"/api/Product/{query}/{offset}");
        }
    }
}
