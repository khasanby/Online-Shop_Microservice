using Ordering.Domain.Common;

namespace Ordering.Domain.Entities
{
    public sealed class Order : BaseEntity
    {
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string UserName { get; internal set; }

        /// <summary>
        /// Gets or sets total price.
        /// </summary>
        public decimal TotalPrice { get; internal set; }

        #region (billingAddress)

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string FirstName { get; internal set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        public string LastName { get; internal set; }

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        public string EmailAddress { get; internal set; }

        /// <summary>
        /// Gets or sets address line.
        /// </summary>
        public string AddressLine { get; internal set; }

        /// <summary>
        /// Gets or sets country name.
        /// </summary>
        public string Country { get; internal set; }

        /// <summary>
        /// Gets or sets state name.
        /// </summary>
        public string State { get; internal set; }

        /// <summary>
        /// Gets or sets zip code.
        /// </summary>
        public string ZipCode { get; internal set; }

        #endregion (billingAddress)

        #region (payment)

        /// <summary>
        /// Gets or sets card name.
        /// </summary>
        public string CardName { get; internal set; }

        /// <summary>
        /// Gets or sets card number.
        /// </summary>
        public string CardNumber { get; internal set; }

        /// <summary>
        /// Gets or sets expiration datetime.
        /// </summary>
        public string Expiration { get; internal set; }

        /// <summary>
        /// Gets or sets cvv number of the card.
        /// </summary>
        public string CVV { get; internal set; }

        /// <summary>
        /// Gets or sets payment method.
        /// </summary>
        public int PaymentMethod { get; internal set; }

        #endregion (payment)
    }
}
