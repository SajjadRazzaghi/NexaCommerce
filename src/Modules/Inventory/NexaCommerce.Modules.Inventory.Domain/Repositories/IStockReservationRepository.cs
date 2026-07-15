using NexaCommerce.Modules.Inventory.Domain.Entities;

namespace NexaCommerce.Modules.Inventory.Domain.Repositories;

public interface IStockReservationRepository
{
    Task AddAsync(
        StockReservation reservation,
        CancellationToken cancellationToken = default);

    Task<StockReservation?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<List<StockReservation>> GetByOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default);

    Task<List<StockReservation>> GetExpiredAsync(
        DateTime utcNow,
        CancellationToken cancellationToken = default);
    Task<List<StockReservation>> GetByWarehouseAsync(
    Guid warehouseId,
    CancellationToken cancellationToken = default);
    Task<List<StockReservation>> GetExpiredAsync(
    CancellationToken cancellationToken = default);

    Task UpdateAsync(
        StockReservation reservation,
        CancellationToken cancellationToken = default);
}
