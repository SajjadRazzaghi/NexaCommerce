using NexaCommerce.Modules.Identity.Application.Abstractions.DateTime;

namespace NexaCommerce.Modules.Identity.Infrastructure.Services;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}