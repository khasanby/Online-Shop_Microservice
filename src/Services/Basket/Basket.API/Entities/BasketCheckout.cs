namespace Basket.API.Entities;

public sealed class BasketCheckout
{
    /// <summary>
    /// Gets or sets user name.
    /// </summary>
    public string UserName { get; set; }
    
    /// <summary>
    /// Gets or sets total price.
    /// </summary>
    public decimal TotalPrice { get; set; }

    #region (billingAddress)
    
    /// <summary>
    /// Gets or sets first name.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Gets or sets last name.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Gets or sets email address.
    /// </summary>
    public string EmailAddress { get; set; }
    
    /// <summary>
    /// Gets or sets address line.
    /// </summary>
    public string AddressLine { get; set; }
    
    /// <summary>
    /// Gets or sets country.
    /// </summary>
    public string Country { get; set; }
    
    /// <summary>
    /// Gets or sets state.
    /// </summary>
    public string State { get; set; }
    
    /// <summary>
    /// Gets or sets zip code.
    /// </summary>
    public string ZipCode { get; set; }
    
    #endregion (billingAddress)

    #region (payment)

    /// <summary>
    /// Gets or sets card name.
    /// </summary>
    public string CardName { get; set; }
    
    /// <summary>
    /// Gets or sets card number.
    /// </summary>
    public string CardNumber { get; set; }
    
    /// <summary>
    /// Gets or sets expiration.
    /// </summary>
    public string Expiration { get; set; }
    
    /// <summary>
    /// Gets or sets CVV.
    /// </summary>
    public string CVV { get; set; }
    
    /// <summary>
    /// Gets or sets payment method.
    /// </summary>
    public int PaymentMethod { get; set; }
    
    #endregion (payment)
}