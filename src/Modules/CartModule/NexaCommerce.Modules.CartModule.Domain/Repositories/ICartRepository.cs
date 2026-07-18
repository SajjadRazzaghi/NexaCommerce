using NexaCommerce.Modules.CartModule.Domain.Entities;

namespace NexaCommerce.Modules.CartModule.Domain.Repositories;

public interface ICartRepository
{
    Task AddAsync(
        Cart cart,
        CancellationToken cancellationToken = default);

    Task<Cart?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Cart?> GetByCustomerAsync(
        Guid customerId,
        CancellationToken cancellationToken = default);
}
