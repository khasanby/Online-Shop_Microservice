using Basket.API.Entities;

namespace Basket.API.Repositories;

public interface IBasketRepository
{
    /// <summary>
    ///     Returns basket by user name.
    /// </summary>
    public Task<ShoppingCartDb> GetBasketAsync(string userName);

    /// <summary>
    ///     Updates the basket.
    /// </summary>
    public Task<ShoppingCartDb> UpdateBasketAsync(ShoppingCartDb basket);

    /// <summary>
    ///     Deletes the basket.
    /// </summary>
    public Task DeleteBasketAsync(string userName);
}