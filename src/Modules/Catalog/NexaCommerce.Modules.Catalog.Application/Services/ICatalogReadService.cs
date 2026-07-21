using NexaCommerce.Contracts.Catalog;

namespace NexaCommerce.Modules.Catalog.Application.Services;

public interface ICatalogReadService
{
    Task<ProductSnapshot?> GetProductAsync(
        Guid productVariantId,
        CancellationToken cancellationToken);
}
