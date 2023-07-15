using ElasticSearchProduct.API.Dto;
using ElasticSearchProduct.API.Models;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ElasticSearchProduct.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> SaveAsync(Product @newProduct);
        Task<ImmutableList<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string @id);
        Task<bool> UpdateAsync(ProductUpdateDTO @productUpdateDTO);
        Task<bool> DeleteAsync(string Id);
    }
}
