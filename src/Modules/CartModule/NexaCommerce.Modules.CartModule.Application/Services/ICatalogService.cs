namespace NexaCommerce.Modules.CartModule.Application.Services;

public interface ICatalogService
{
    Task<decimal> GetVariantPriceAsync(
        Guid productVariantId,
        CancellationToken cancellationToken);

    Task<bool> VariantExistsAsync(
        Guid productVariantId,
        CancellationToken cancellationToken);
}