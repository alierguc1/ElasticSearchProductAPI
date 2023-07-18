using AutoMapper;
using ElasticSearchProduct.API.Dto;
using ElasticSearchProduct.API.Models;

namespace ElasticSearchProduct.API.Mapping
{
    public class GeneralMapping : AutoMapper.Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductCreateDTO>();
            CreateMap<ProductFeature, ProductFeatureDTO>();  
        }
    }
}
