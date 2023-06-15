using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public sealed class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var db = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            var Products = db.GetCollection<ProductDb>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<ProductDb> Products { get; }
    }
}