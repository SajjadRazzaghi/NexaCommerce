namespace NexaCommerce.Modules.Inventory.Application.Features.Transactions.GetTransactions;

public sealed record TransactionDto(
    Guid Id,
    Guid WarehouseId,
    int Quantity,
    string Type,
    string Description,
    DateTime CreatedOnUtc);
