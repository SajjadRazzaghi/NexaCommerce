using MediatR;

using NexaCommerce.Modules.OrderModule.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.PayOrder;

internal sealed class PayOrderCommandHandler
    : IRequestHandler<PayOrderCommand>
{
    private readonly IOrderRepository _orders;
    private readonly IUnitOfWork _unitOfWork;

    public PayOrderCommandHandler(
        IOrderRepository orders,
        IUnitOfWork unitOfWork)
    {
        _orders = orders;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        PayOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _orders.GetByIdAsync(
            request.OrderId,
            cancellationToken);

        if (order is null)
            return;

        order.MarkPaid();

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);
    }
}
