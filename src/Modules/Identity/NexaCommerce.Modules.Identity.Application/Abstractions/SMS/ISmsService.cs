namespace NexaCommerce.Modules.Identity.Application.Abstractions.Sms;

public interface ISmsService
{
    Task SendAsync(
        string phoneNumber,
        string message,
        CancellationToken cancellationToken = default);
}
