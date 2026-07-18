namespace NexaCommerce.Modules.CartModule.Application.Services;

public interface IInventoryService
{
    Task<bool> HasEnoughStockAsync(
        Guid productVariantId,
        int quantity,
        CancellationToken cancellationToken);
}