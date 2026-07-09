using System;

namespace NexaCommerce.Modules.Identity.Application.Abstractions.Date_Time;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
