using Elastic.Clients.Elasticsearch;
using ElasticSearchProduct.API.Dto;
using ElasticSearchProduct.API.Models;
using ElasticSearchProduct.API.Repositories.Interfaces;
using System.Collections.Immutable;

namespace ElasticSearchProduct.API.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElasticsearchClient _elasticClient;
        private const string indexName = "products";
        public ProductRepository(ElasticsearchClient elasticClient)
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

            if (!response.IsSuccess()) return null;
            newProduct.Id = response.Id;
            return newProduct;
        }

        public async Task<Product?> GetByIdAsync(string @id)
        {
            var response = await _elasticClient.GetAsync<Product>(id, x => x.Index(indexName));
            if (!response.IsSuccess()) return null;
            response.Source.Id = response.Id;
            return response.Source;
        }

        public async Task<bool> UpdateAsync(ProductUpdateDTO productUpdateDTO)
        {
            var response = await _elasticClient.UpdateAsync
                <Product,ProductUpdateDTO>(indexName, productUpdateDTO.Id,x=>x.Doc(productUpdateDTO));

            return response.IsSuccess();
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var response = await _elasticClient.DeleteAsync
               <Product>(Id, x => x.Index(indexName));

            return response.IsSuccess();
        }
    }
}
