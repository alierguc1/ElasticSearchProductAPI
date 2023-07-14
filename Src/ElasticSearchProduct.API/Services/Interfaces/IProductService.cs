using ElasticSearchProduct.API.Dto;
using ElasticSearchProduct.API.Models;

namespace ElasticSearchProduct.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductReponseDTO<ProductDTO>> SaveAsync(ProductCreateDTO productCreateDTO);
    }
}
