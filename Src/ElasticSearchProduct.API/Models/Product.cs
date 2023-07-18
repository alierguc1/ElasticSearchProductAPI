using ElasticSearchProduct.API.Dto;

namespace ElasticSearchProduct.API.Models
{
    public class Product
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string StockCode { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int WarrantyPeriod { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public ProductFeature? Feature { get; set; }

        public ProductDTO CreateDto()
        {
            if(Feature == null)
            {
                return new ProductDTO(Id, Name, StockCode, Price, Stock, WarrantyPeriod, null);
            }

            return new ProductDTO(Id, Name, StockCode, Price, Stock, WarrantyPeriod, new ProductFeatureDTO(Feature.Width, Feature.Height, Feature.Color.ToString()));
        }

    }
}
