using AutoMapper;
using ElasticSearchProduct.API.Dto;
using ElasticSearchProduct.API.Models;
using Nest;

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
