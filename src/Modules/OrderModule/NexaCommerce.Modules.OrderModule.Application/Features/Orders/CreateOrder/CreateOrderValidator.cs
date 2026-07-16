using FluentValidation;

namespace NexaCommerce.Modules.OrderModule.Application.Features.Orders.CreateOrder;

internal sealed class CreateOrderValidator
    : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty();

        RuleFor(x => x.Items)
            .NotEmpty();

        RuleForEach(x => x.Items)
            .ChildRules(item =>
            {
                item.RuleFor(x => x.Quantity)
                    .GreaterThan(0);

                item.RuleFor(x => x.UnitPrice)
                    .GreaterThan(0);
            });
    }
}
