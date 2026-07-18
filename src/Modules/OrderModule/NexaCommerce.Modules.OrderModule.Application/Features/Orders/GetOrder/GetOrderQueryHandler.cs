using MediatR;

using NexaCommerce.Modules.OrderModule.Domain.Entities;
using NexaCommerce.Modules.OrderModule.Domain.Repositories;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.GetOrder;

internal sealed class GetOrderQueryHandler
    : IRequestHandler<GetOrderQuery, Order?>
{
    private readonly IOrderRepository _orders;

    public GetOrderQueryHandler(
        IOrderRepository orders)
    {
        _orders = orders;
    }

    public async Task<Order?> Handle(
        GetOrderQuery request,
        CancellationToken cancellationToken)
    {
        return await _orders.GetByIdAsync(
            request.OrderId,
            cancellationToken);
    }
}
