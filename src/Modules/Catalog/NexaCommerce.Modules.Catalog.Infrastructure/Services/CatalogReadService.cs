using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Catalog.Application.Services;
using NexaCommerce.Modules.Catalog.Infrastructure.Persistence;

namespace NexaCommerce.Modules.Catalog.Infrastructure.Services;

internal sealed class CatalogReadService
    : ICatalogReadService
{
    private readonly CatalogDbContext _context;

    public CatalogReadService(
        CatalogDbContext context)
    {
        _context = context;
    }

    public async Task<ProductSnapshotDto?> GetProductAsync(
        Guid productVariantId,
        CancellationToken cancellationToken)
    {
        return await _context.ProductVariants
            .Where(x => x.Id == productVariantId)
            .Select(x => new ProductSnapshotDto(
                x.Id,
                x.Name,
                x.Price,
                x.IsActive))
            .FirstOrDefaultAsync(cancellationToken);
    }

    Task<ProductSnapshot?> ICatalogReadService.GetProductAsync(Guid productVariantId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
