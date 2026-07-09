namespace NexaCommerce.SharedKernel.Primitives;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
}