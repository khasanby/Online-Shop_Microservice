using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories;

public sealed class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
    }

    /// <summary>
    ///     Returns basket by user name.
    /// </summary>
    public async Task<ShoppingCartDb> GetBasketAsync(string userName)
    {
        var basket = await _redisCache.GetStringAsync(userName);

        if (string.IsNullOrEmpty(basket))
            return null;
        return JsonConvert.DeserializeObject<ShoppingCartDb>(basket);
    }

    /// <summary>
    ///     Updates the basket.
    /// </summary>
    public async Task<ShoppingCartDb> UpdateBasketAsync(ShoppingCartDb basket)
    {
        await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

        return await GetBasketAsync(basket.UserName);
    }

    /// <summary>
    ///     Deletes the basket.
    /// </summary>
    public async Task DeleteBasketAsync(string userName)
    {
        await _redisCache.RemoveAsync(userName);
    }
}