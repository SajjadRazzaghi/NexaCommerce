using NexaCommerce.Modules.Order.Domain.Entities;


namespace NexaCommerce.Modules.Order.Domain.Repositories;

public interface IOrderRepository
{
    Task AddAsync(
        Order order,
        CancellationToken cancellationToken = default);

    Task<Order?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<List<Order>> GetByCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default);

    Task<List<Order>> GetAllAsync(
        CancellationToken cancellationToken = default);
}
