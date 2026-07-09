using NexaCommerce.SharedKernel.DomainEvents;

namespace NexaCommerce.Modules.Identity.Domain.Events;

public sealed class UserRegisteredEvent(Guid userId)
    : DomainEvent
{
    public Guid UserId { get; } = userId;
}