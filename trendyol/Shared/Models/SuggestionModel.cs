namespace trendyol.Shared.Models
{
    public class SuggestionModel
    {
        public string? targetUrl { get; set; }
        public string? text { get; set; }
        public string? persiantext { get; set; }
        public string? label { get; set; }
        public string? imageUrl { get; set; }
        public ICollection<string>? markers { get; set; }
        public ICollection<string>? sellerBadges { get; set; }

    }
}
