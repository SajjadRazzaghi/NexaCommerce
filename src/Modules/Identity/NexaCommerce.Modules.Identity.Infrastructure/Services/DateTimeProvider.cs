using NexaCommerce.Modules.Identity.Application.Abstractions.Date_Time;

namespace NexaCommerce.Modules.Identity.Infrastructure.Services;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}