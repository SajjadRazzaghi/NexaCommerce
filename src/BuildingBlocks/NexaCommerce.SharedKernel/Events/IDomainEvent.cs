namespace NexaCommerce.SharedKernel.Events;

public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}