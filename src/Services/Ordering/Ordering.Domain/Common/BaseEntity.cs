namespace Ordering.Domain.Common
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// Gets or sets creator name.
        /// </summary>
        public string CreatedBy { get; internal set; }

        /// <summary>
        /// Gets or sets created date.
        /// </summary>
        public DateTime CreatedDate { get; internal set; }

        /// <summary>
        /// Gets or sets last modifier name.
        /// </summary>
        public string LastModifiedBy { get; internal set; }

        /// <summary>
        /// Gets or sets last modification date.
        /// </summary>
        public DateTime? LastModifiedDate { get; internal set; }
    }
}