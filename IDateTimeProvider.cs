namespace NexaCommerce.Modules.Identity.Application.Abstractions.DateTime;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}