using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.CartModule.Domain.Entities;
using NexaCommerce.Modules.CartModule.Domain.Repositories;

namespace NexaCommerce.Modules.CartModule.Infrastructure.Persistence.Repositories;

internal sealed class CartRepository
    : ICartRepository
{
    private readonly CartDbContext _context;

    public CartRepository(
        CartDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Cart cart,
        CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(
            cart,
            cancellationToken);
    }

    public async Task<Cart?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(x => x.Items)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<Cart?> GetByCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(x => x.Items)
            .FirstOrDefaultAsync(
                x => x.CustomerId == customerId,
                cancellationToken);
    }
}