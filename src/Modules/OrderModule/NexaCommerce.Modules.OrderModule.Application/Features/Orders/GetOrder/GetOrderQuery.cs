using MediatR;

using NexaCommerce.Modules.OrderModule.Domain.Entities;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.GetOrder;

public sealed record GetOrderQuery(
    Guid OrderId)
    : IRequest<Order?>;
