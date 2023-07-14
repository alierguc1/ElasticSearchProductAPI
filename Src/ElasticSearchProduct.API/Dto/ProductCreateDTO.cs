using AutoMapper.Features;
using ElasticSearchProduct.API.Models;
using ElasticSearchProduct.API.Models.Enums;

namespace ElasticSearchProduct.API.Dto
{
    public record ProductCreateDTO(string Name, string StockCode, decimal Price,int Stock, int WarrantyPeriod, ProductFeatureDTO Feature)
    {

        public Product CreateProduct()
        {
            return new Product
            {
                Name = Name,
                StockCode = StockCode,
                Price = Price,
                Stock = Stock,
                WarrantyPeriod = WarrantyPeriod,
                Feature = new ProductFeature() { Width = Feature.width, Height = Feature.height, Color = (ProductColor)int.Parse(Feature.color)}
            };
        }
    }
}
