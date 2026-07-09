namespace NexaCommerce.SharedKernel.Primitives;

public readonly record struct EntityId(Guid Value)
{
    public static EntityId New() => new(Guid.NewGuid());

    public override string ToString()
        => Value.ToString();

    public static implicit operator Guid(EntityId id)
        => id.Value;

    public static implicit operator EntityId(Guid value)
        => new(value);
}