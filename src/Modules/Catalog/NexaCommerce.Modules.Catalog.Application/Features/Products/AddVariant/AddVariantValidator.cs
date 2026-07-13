using FluentValidation;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.AddVariant;

public sealed class AddVariantValidator
    : AbstractValidator<AddVariantCommand>
{
    public AddVariantValidator()
    {
        RuleFor(x => x.Sku)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0);
    }
}
