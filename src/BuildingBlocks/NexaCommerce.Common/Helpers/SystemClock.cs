using NexaCommerce.SharedKernel.Interfaces;

namespace NexaCommerce.Common.Helpers;

public sealed class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}