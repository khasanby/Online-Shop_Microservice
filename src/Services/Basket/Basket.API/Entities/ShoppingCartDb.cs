namespace Basket.API.Entities;

public sealed class ShoppingCartDb
{
    public ShoppingCartDb()
    {
    }

    public ShoppingCartDb(string userName)
    {
        UserName = userName;
    }

    /// <summary>
    ///     Gets and sets user name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    ///     Gets and sets items.
    /// </summary>
    public IEnumerable<ShoppingCartItemDb> Items { get; set; } = new List<ShoppingCartItemDb>();

    public decimal TotalPrice
    {
        get
        {
            decimal totalprice = 0;
            foreach (var item in Items) totalprice += item.Price * item.Quantity;
            return totalprice;
        }
    }
}