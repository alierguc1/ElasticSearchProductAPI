using ElasticSearchProduct.API.Models;

namespace ElasticSearchProduct.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> SaveAsync(Product @newProduct);
    }
}
