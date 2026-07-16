using MediatR;

using NexaCommerce.Modules.OrderModule.Application.DTOs;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(
    Guid CustomerId,
    CreateOrderAddressDto Address,
    List<CreateOrderItemDto> Items)
    : IRequest<Result<Guid>>;
