using AutoMapper;
using ElasticSearchProduct.API.Dto;
using ElasticSearchProduct.API.Models;
using ElasticSearchProduct.API.Repositories.Interfaces;
using ElasticSearchProduct.API.Services.Interfaces;

namespace ElasticSearchProduct.API.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductReponseDTO<ProductDTO>> SaveAsync(ProductCreateDTO productCreateDTO)
        {
          
            var response = await _productRepository.SaveAsync(productCreateDTO.CreateProduct());

            if (response == null) return ProductReponseDTO<ProductDTO>.Fail(new List<string>{ "Ürün oluşturulurken bir hata meydana geldi." },System.Net.HttpStatusCode.InternalServerError);
            return ProductReponseDTO<ProductDTO>.Success(response.CreateDto(), System.Net.HttpStatusCode.OK);


        }
    }
}
