namespace NexaCommerce.SharedKernel.DomainEvents;

public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}