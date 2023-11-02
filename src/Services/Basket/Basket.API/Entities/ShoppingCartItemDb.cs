namespace Basket.API.Entities;

public sealed class ShoppingCartItemDb
{
    /// <summary>
    ///     Gets and sets quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    ///     Gets and sets color.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    ///     Gets and sets price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    ///     Gets and sets product id.
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    ///     Gets and sets product name.
    /// </summary>
    public string ProductName { get; set; }
}