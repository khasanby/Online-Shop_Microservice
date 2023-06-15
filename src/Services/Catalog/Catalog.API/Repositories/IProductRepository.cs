using Catalog.API.Models;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDb>> GetAllProductsAsync();
        Task<ProductDb> GetProductByIdAsync(string id);
        Task<IEnumerable<ProductDb>> GetProductByNameAsync(string name);
        Task<IEnumerable<ProductDb>> GetProductsByCategoryAsync(string categoryName);

        Task CreateProductAsync(ProductDb product);
        Task<bool> UpdateProductAsync(ProductDb product);
        Task<bool> DeleteProductByIdAsync(string id);
    }
}