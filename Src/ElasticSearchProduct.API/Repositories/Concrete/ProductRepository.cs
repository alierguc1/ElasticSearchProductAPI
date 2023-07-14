using ElasticSearchProduct.API.Models;
using ElasticSearchProduct.API.Repositories.Interfaces;
using Nest;

namespace ElasticSearchProduct.API.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElasticClient _elasticClient;
        public ProductRepository(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<Product> SaveAsync(Product newProduct)
        {
            newProduct.Created = DateTime.Now;
            var response = await _elasticClient.IndexAsync(newProduct, x => x.Index("products"));

            if (!response.IsValid) return null;
            newProduct.Id = response.Id;
            return newProduct;
        }
    }
}
