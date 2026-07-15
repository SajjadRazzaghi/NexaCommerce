using MediatR;

using NexaCommerce.Modules.Inventory.Domain.Repositories;

namespace NexaCommerce.Modules.Inventory.Application.Features.Transactions.GetTransactions;

internal sealed class GetTransactionsQueryHandler
    : IRequestHandler<GetTransactionsQuery, List<TransactionDto>>
{
    private readonly IStockMovementRepository _repository;

    public GetTransactionsQueryHandler(
        IStockMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TransactionDto>> Handle(
        GetTransactionsQuery request,
        CancellationToken cancellationToken)
    {
        var list =
            await _repository.GetByVariantAsync(
                request.ProductVariantId,
                cancellationToken);

        return list
            .Select(x =>
               new TransactionDto(
    x.Id,
    x.WarehouseId,
    x.Quantity,
    x.Type,
    x.Description ?? string.Empty,
    x.CreatedOnUtc))
            .ToList();
    }
}
