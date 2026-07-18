using MediatR;

using NexaCommerce.Modules.OrderModule.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.CancelOrder;

internal sealed class CancelOrderCommandHandler
    : IRequestHandler<CancelOrderCommand>
{
    private readonly IOrderRepository _orders;
    private readonly IUnitOfWork _unitOfWork;

    public CancelOrderCommandHandler(
        IOrderRepository orders,
        IUnitOfWork unitOfWork)
    {
        _orders = orders;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        CancelOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _orders.GetByIdAsync(
            request.OrderId,
            cancellationToken);

        if (order is null)
            return;

        order.Cancel();

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
}
