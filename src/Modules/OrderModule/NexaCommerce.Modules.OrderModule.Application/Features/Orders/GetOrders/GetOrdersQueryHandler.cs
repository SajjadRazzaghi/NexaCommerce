using MediatR;

using NexaCommerce.Modules.OrderModule.Domain.Entities;
using NexaCommerce.Modules.OrderModule.Domain.Repositories;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.GetOrders;

internal sealed class GetOrdersQueryHandler
    : IRequestHandler<GetOrdersQuery, List<Order>>
{
    private readonly IOrderRepository _orders;

    public GetOrdersQueryHandler(
        IOrderRepository orders)
    {
        _orders = orders;
    }

    public async Task<List<Order>> Handle(
        GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await _orders.GetCustomerOrdersAsync(
            request.CustomerId,
            cancellationToken);
    }
}
