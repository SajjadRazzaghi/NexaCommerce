using NexaCommerce.SharedKernel.Events;

namespace NexaCommerce.SharedKernel.Interfaces;

public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();
}