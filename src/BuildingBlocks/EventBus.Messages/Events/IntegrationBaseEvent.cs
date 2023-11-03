namespace EventBus.Messages.Events;

public class IntegrationBaseEvent
{
    public IntegrationBaseEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }
    
    /// <summary>
    /// Gets the id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the creation date.
    /// </summary>
    public DateTime CreationDate { get; init; }
}