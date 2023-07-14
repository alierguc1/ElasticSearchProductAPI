using ElasticSearchProduct.API.Models;
using System.Collections.Immutable;

namespace ElasticSearchProduct.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> SaveAsync(Product @newProduct);
        Task<ImmutableList<Product>> GetAllAsync();
    }
}
