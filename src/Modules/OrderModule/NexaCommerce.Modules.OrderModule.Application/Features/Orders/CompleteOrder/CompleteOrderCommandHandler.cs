using MediatR;

using NexaCommerce.Modules.OrderModule.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.CompleteOrder;

internal sealed class CompleteOrderCommandHandler
    : IRequestHandler<CompleteOrderCommand>
{
    private readonly IOrderRepository _orders;
    private readonly IUnitOfWork _unitOfWork;

    public CompleteOrderCommandHandler(
        IOrderRepository orders,
        IUnitOfWork unitOfWork)
    {
        _orders = orders;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        CompleteOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _orders.GetByIdAsync(
            request.OrderId,
            cancellationToken);

        if (order is null)
            return;

        order.Deliver();

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
}
