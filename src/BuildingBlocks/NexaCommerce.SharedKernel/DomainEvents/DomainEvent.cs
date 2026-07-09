namespace NexaCommerce.SharedKernel.DomainEvents;

public abstract record DomainEvent : IDomainEvent
{
    public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;
}