using MediatR;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.CompleteOrder;

public sealed record CompleteOrderCommand(
    Guid OrderId)
    : IRequest;
