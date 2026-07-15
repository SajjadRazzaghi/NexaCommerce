using FluentValidation;

namespace NexaCommerce.Modules.Catalog.Application.Features.Variants.CreateProductVariant;

public sealed class CreateProductVariantValidator
    : AbstractValidator<CreateProductVariantCommand>
{
    public CreateProductVariantValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Sku)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.OldPrice)
            .GreaterThanOrEqualTo(x => x.Price)
            .When(x => x.OldPrice.HasValue);
    }
}
