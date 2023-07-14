using ElasticSearchProduct.API.Models;
using ElasticSearchProduct.API.Repositories.Interfaces;
using Nest;
using System.Collections.Immutable;

namespace ElasticSearchProduct.API.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElasticClient _elasticClient;
        private const string indexName = "products";
        public ProductRepository(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        // ImmutableList değişime kapalıdır. Değişiklik yapılamaz. 
        public async Task<ImmutableList<Product>> GetAllAsync()
        {
            var result = await _elasticClient.SearchAsync<Product>(x => x.Index(indexName).Query(q=>q.MatchAll()));
            foreach (var hit in result.Hits) { hit.Source.Id = hit.Id; }
            return result.Documents.ToImmutableList();
        }

        public async Task<Product> SaveAsync(Product newProduct)
        {
            newProduct.Created = DateTime.Now;
            var response = await _elasticClient.IndexAsync(newProduct, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));

            if (!response.IsValid) return null;
            newProduct.Id = response.Id;
            return newProduct;
        }

        public async Task<Product?> GetByIdAsync(string @id)
        {
            var response = await _elasticClient.GetAsync<Product>(id, x => x.Index(indexName));
            if (!response.IsValid) return null;
            response.Source.Id = response.Id;
            return response.Source;
        }
    }
}
