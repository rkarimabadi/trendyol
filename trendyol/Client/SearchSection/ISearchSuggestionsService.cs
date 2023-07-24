using trendyol.Shared.Models;

namespace trendyol.Client.SearchSection
{
    public interface ISearchSuggestionsService
    {
        Task<GenericResponseModel<ICollection<SuggestionModel>>> Suggestions(string query);
    }
}