using ElasticSearchProduct.API.Models.Enums;

namespace ElasticSearchProduct.API.Models
{
    public class ProductFeature
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ProductColor Color { get; set; }
    }
}
