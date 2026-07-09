namespace NexaCommerce.SharedKernel.Interfaces;

public interface IClock
{
    DateTime UtcNow { get; }
}