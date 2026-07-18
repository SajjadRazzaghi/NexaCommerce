using MediatR;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.PayOrder;

public sealed record PayOrderCommand(
    Guid OrderId)
    : IRequest;
