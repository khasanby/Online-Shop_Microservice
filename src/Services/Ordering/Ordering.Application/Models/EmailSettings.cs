namespace Ordering.Application.Models
{
    internal sealed class EmailSettings
    {
        /// <summary>
        /// Gets or sets api key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets sender address.
        /// </summary>
        public string FromAddress { get; set; }

        /// <summary>
        /// Gets or sets sender's name.
        /// </summary>
        public string FromName { get; set; }
    }
}