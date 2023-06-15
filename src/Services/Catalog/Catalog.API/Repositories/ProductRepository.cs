using Catalog.API.Data;
using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Instance of catalog context.
        /// </summary>
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Returns all products.
        /// </summary>
        public async Task<IEnumerable<ProductDb>> GetAllProductsAsync()
        {
            var products = await _context.Products.Find(p => true).ToListAsync();
            return products;
        }

        /// <summary>
        /// Returns a product by id.
        /// </summary>
        public async Task<ProductDb> GetProductByIdAsync(string id)
        {
            return await _context.Products
                                 .Find(p => p.Id == id)
                                 .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns a product by name.
        /// </summary>
        public async Task<IEnumerable<ProductDb>> GetProductByNameAsync(string name)
        {
            FilterDefinition<ProductDb> filter = Builders<ProductDb>.Filter.Eq(p => p.Name, name);

            return await _context.Products
                                 .Find(filter)
                                 .ToListAsync();
        }

        /// <summary>
        /// Returns a collection of products by category.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDb>> GetProductsByCategoryAsync(string categoryName)
        {
            FilterDefinition<ProductDb> filter = Builders<ProductDb>.Filter.Eq(p => p.Category, categoryName);

            return await _context.Products
                                 .Find(filter)
                                 .ToListAsync();
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        public async Task CreateProductAsync(ProductDb product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        public async Task<bool> UpdateProductAsync(ProductDb product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged &&
                   updateResult.ModifiedCount > 0;
        }

        /// <summary>
        /// Deletes a product by id.
        /// </summary>
        public async Task<bool> DeleteProductByIdAsync(string id)
        {
            FilterDefinition<ProductDb> filter = Builders<ProductDb>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged &&
                   deleteResult.DeletedCount > 0;
        }
    }
}