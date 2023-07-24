namespace trendyol.Shared.Models
{
    public class Badge
    {
        public string title { get; set; }
        public string type { get; set; }
        public bool priority { get; set; }
    }

    public class Brand
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Price
    {
        public double discountedPrice { get; set; }
        public int buyingPrice { get; set; }
        public double originalPrice { get; set; }
        public double sellingPrice { get; set; }
    }

    public class Promotion
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public DateTime promotionEndDate { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<string> images { get; set; }
        public string imageAlt { get; set; }
        public Brand brand { get; set; }
        public int tax { get; set; }
        public bool showSexualContent { get; set; }
        public int productGroupId { get; set; }
        public bool hasReviewPhoto { get; set; }
        public string cardType { get; set; }
        public List<Section> sections { get; set; }
        public List<Variant> variants { get; set; }
        public string categoryHierarchy { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string url { get; set; }
        public int merchantId { get; set; }
        public int campaignId { get; set; }
        public Price price { get; set; }
        public List<Promotion> promotions { get; set; }
        public int rushDeliveryDuration { get; set; }
        public bool freeCargo { get; set; }
        public string campaignName { get; set; }
        public string listingId { get; set; }
        public string winnerVariant { get; set; }
        public int itemNumber { get; set; }
        public string discountedPriceInfo { get; set; }
        public bool hasVideoContent { get; set; }
        public bool hasCrossPromotion { get; set; }
        public bool hasCollectableCoupon { get; set; }
        public bool sameDayShipping { get; set; }
        public bool isLegalRequirementConfirmed { get; set; }
        public List<Badge> badges { get; set; }
    }

    public class Section
    {
        public string id { get; set; }
    }

    public class Variant
    {
        public string attributeValue { get; set; }
        public string attributeName { get; set; }
        public Price price { get; set; }
        public string listingId { get; set; }
        public int campaignId { get; set; }
        public int merchantId { get; set; }
        public string discountedPriceInfo { get; set; }
        public bool hasCollectableCoupon { get; set; }
        public bool sameDayShipping { get; set; }
    }

    public class ProductModel {
        public ICollection<Product> Products { get; set; }
        public int totalCount { get; set; }
        public int offset { get; set; }
        public string roughTotalCount { get; set; }
        public string searchStrategy { get; set; }
        public string title { get; set; }
        public string uxLayout { get; set; }
        public string queryTerm { get; set; }
        public int pageIndex { get; set; }

    }
}
