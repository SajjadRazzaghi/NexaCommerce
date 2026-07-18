using MediatR;

using NexaCommerce.Modules.OrderModule.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.ShipOrder;

internal sealed class ShipOrderCommandHandler
    : IRequestHandler<ShipOrderCommand>
{
    private readonly IOrderRepository _orders;
    private readonly IUnitOfWork _unitOfWork;

    public ShipOrderCommandHandler(
        IOrderRepository orders,
        IUnitOfWork unitOfWork)
    {
        _orders = orders;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        ShipOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _orders.GetByIdAsync(
            request.OrderId,
            cancellationToken);

        if (order is null)
            return;

        order.Ship();

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
}
