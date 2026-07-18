namespace NexaCommerce.Modules.OrderModule.Infrastructure.Services;

public sealed class OrderNumberGenerator
{
    public string Generate()
    {
        return $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}";
    }
}
