using MediatR;

using NexaCommerce.Modules.OrderModule.Domain.Entities;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.GetOrders;

public sealed record GetOrdersQuery(
    Guid CustomerId)
    : IRequest<List<Order>>;
