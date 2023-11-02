using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.Data;

public interface ICatalogContext
{
    /// <summary>
    ///     Gets a collection of products.
    /// </summary>
    IMongoCollection<ProductDb> Products { get; }
}