namespace NexaCommerce.SharedKernel.Primitives;

public abstract class AuditableEntity<TId> : AggregateRoot<TId>
    where TId : notnull
{
    public DateTime CreatedOnUtc { get; protected set; }

    public Guid? CreatedBy { get; protected set; }

    public DateTime? ModifiedOnUtc { get; protected set; }

    public Guid? ModifiedBy { get; protected set; }

    public DateTime? DeletedOnUtc { get; protected set; }

    public Guid? DeletedBy { get; protected set; }

    public bool IsDeleted { get; protected set; }

    public byte[] RowVersion { get; protected set; } = Array.Empty<byte>();

    protected void MarkAsDeleted(Guid? deletedBy = null)
    {
        IsDeleted = true;
        DeletedOnUtc = DateTime.UtcNow;
        DeletedBy = deletedBy;
    }
}