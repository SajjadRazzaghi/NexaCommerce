using MediatR;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.CancelOrder;

public sealed record CancelOrderCommand(
    Guid OrderId)
    : IRequest;
