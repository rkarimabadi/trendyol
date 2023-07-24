using trendyol.Shared.Models;

namespace trendyol.Client.ProductSection
{
    public interface IProductService
    {
        Task<GenericResponseModel<ProductModel>> Products(string query, int offset);
    }
}