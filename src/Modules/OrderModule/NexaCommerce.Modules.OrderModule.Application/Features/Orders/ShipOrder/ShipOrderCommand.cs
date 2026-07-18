using MediatR;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.ShipOrder;

public sealed record ShipOrderCommand(
    Guid OrderId)
    : IRequest;
