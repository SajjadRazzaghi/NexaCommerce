using MediatR;

using NexaCommerce.Modules.Inventory.Application.Abstractions;
using NexaCommerce.Modules.OrderModule.Domain.Entities;
using NexaCommerce.Modules.OrderModule.Domain.Repositories;
using NexaCommerce.Modules.OrderModule.Domain.ValueObjects;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.CreateOrder;

internal sealed class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    private readonly IOrderRepository _orders;

    private readonly IInventoryService _inventory;

    private readonly IUnitOfWork _unitOfWork;

 

    public CreateOrderCommandHandler(
        IOrderRepository orders,
        IInventoryService inventory,
        IUnitOfWork unitOfWork)
    {
        _orders = orders;
        _inventory = inventory;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        foreach (var item in request.Items)
        {
            var reserved =
                await _inventory.ReserveStockAsync(
                    Guid.Empty,
                    item.ProductVariantId,
                    Guid.NewGuid(),
                    item.Quantity,
                    cancellationToken);

            if (!reserved)
            {
                return Result<Guid>.Failure(
                    new Error(
                        "Inventory.NotEnough",
                        $"Stock is not enough for {item.ProductVariantId}."));
            }
        }

        var address =
            OrderAddress.Create(
                request.Address.Province,
                request.Address.City,
                request.Address.Address,
                request.Address.PostalCode,
                request.Address.ReceiverName,
                request.Address.PhoneNumber);

        var order =
            Order.Create(
                request.CustomerId,
                address);

        foreach (var item in request.Items)
        {
            order.AddItem(
                OrderItem.Create(
                    order.Id,
                    item.ProductVariantId,
                    item.Quantity,
                    item.UnitPrice));
        }

        await _orders.AddAsync(
            order,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<Guid>.Success(order.Id);
    }
}
