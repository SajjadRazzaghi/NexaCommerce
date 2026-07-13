using NexaCommerce.Modules.Identity.Application.Abstractions.Sms;

namespace NexaCommerce.Modules.Identity.Infrastructure.Sms;

public sealed class FakeSmsService : ISmsService
{
    public Task SendAsync(
        string phoneNumber,
        string message,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"SMS To : {phoneNumber}");
        Console.WriteLine(message);
        Console.WriteLine("--------------------------------");

        return Task.CompletedTask;
    }
}
