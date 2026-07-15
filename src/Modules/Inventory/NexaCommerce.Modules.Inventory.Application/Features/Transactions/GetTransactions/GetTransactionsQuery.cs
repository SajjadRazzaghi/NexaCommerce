using MediatR;

namespace NexaCommerce.Modules.Inventory.Application.Features.Transactions.GetTransactions;

public sealed record GetTransactionsQuery(
    Guid ProductVariantId)
    : IRequest<List<TransactionDto>>;
