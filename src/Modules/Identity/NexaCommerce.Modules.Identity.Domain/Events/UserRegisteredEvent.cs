using NexaCommerce.SharedKernel.Events;

namespace NexaCommerce.Modules.Identity.Domain.Events;

public sealed record UserRegisteredEvent(Guid UserId)
    : DomainEvent;