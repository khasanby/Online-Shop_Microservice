namespace Ordering.Domain.Common;

public abstract class BaseEntity
{
    /// <summary>
    ///     Gets or sets id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets creator name.
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    ///     Gets or sets created date.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    ///     Gets or sets last modifier name.
    /// </summary>
    public string LastModifiedBy { get; set; }

    /// <summary>
    ///     Gets or sets last modification date.
    /// </summary>
    public DateTime? LastModifiedDate { get; set; }
}