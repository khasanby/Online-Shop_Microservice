namespace Ordering.Application.Models
{
    public sealed class Email
    {
        /// <summary>
        /// Gets or sets receiver.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets message body.
        /// </summary>
        public string Body { get; set; }
    }
}