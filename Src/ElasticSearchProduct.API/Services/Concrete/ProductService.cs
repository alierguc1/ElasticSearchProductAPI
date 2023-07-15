using AutoMapper;
using ElasticSearchProduct.API.Dto;
using ElasticSearchProduct.API.Models;
using ElasticSearchProduct.API.Repositories.Interfaces;
using ElasticSearchProduct.API.Services.Interfaces;
using Nest;
using System.Collections.Immutable;
using System.Net;

namespace ElasticSearchProduct.API.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductReponseDTO<List<ProductDTO>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productListDto = products.Select(x =>
                new ProductDTO(x.Id, x.Name,
                x.StockCode, x.Price,
                x.Stock, x.WarrantyPeriod, new ProductFeatureDTO(x.Feature.Width, x.Feature.Height, x.Feature.Color.ToString()))).ToList();

            return ProductReponseDTO<List<ProductDTO>>.Success(productListDto, HttpStatusCode.OK);
        }

        public async Task<ProductReponseDTO<ProductDTO?>> GetByIdAsync(string id)
        {
            var hasProduct = await _productRepository.GetByIdAsync(id);
            if(hasProduct==null) return ProductReponseDTO<ProductDTO?>.Fail("Ürün Bulunamadı.", HttpStatusCode.OK);
            return ProductReponseDTO<ProductDTO?>.Success(hasProduct.CreateDto(), HttpStatusCode.OK);
        }

        public async Task<ProductReponseDTO<ProductDTO>> SaveAsync(ProductCreateDTO productCreateDTO)
        {     
            var response = await _productRepository.SaveAsync(productCreateDTO.CreateProduct());

            if (response == null) return ProductReponseDTO<ProductDTO>.Fail(new List<string>{ "Ürün oluşturulurken bir hata meydana geldi." },System.Net.HttpStatusCode.InternalServerError);
            return ProductReponseDTO<ProductDTO>.Success(response.CreateDto(), System.Net.HttpStatusCode.OK);
        }

        public async Task<ProductReponseDTO<bool>> UpdateAsync(ProductUpdateDTO productUpdateDTO)
        {
            var isSuccess = await _productRepository.UpdateAsync(productUpdateDTO); 
            if(!isSuccess) return ProductReponseDTO<bool>.Fail(new List<string> { "" }, System.Net.HttpStatusCode.BadRequest);
            return ProductReponseDTO<bool>.Success(true, System.Net.HttpStatusCode.OK);
        }
    }
}
