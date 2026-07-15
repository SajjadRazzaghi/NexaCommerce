using Microsoft.EntityFrameworkCore;

using NexaCommerce.Modules.Order.Domain.Entities;
using NexaCommerce.Modules.Order.Domain.Repositories;

namespace NexaCommerce.Modules.Order.Infrastructure.Persistence.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _context;

    public OrderRepository(OrderDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order,CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(order,cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(Guid id,CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
    }

    public async Task<List<Order>> GetByCustomerAsync(Guid customerId,CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .Include(x => x.Items)
            .Where(x => x.CustomerId == customerId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .Include(x => x.Items)
            .ToListAsync(cancellationToken);
    }
}
