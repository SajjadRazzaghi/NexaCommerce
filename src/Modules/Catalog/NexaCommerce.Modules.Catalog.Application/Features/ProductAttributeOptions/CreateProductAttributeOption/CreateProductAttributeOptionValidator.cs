using FluentValidation;

namespace NexaCommerce.Modules.Catalog.Application.Features.ProductAttributeOptions.CreateProductAttributeOption;

public sealed class CreateProductAttributeOptionValidator
    : AbstractValidator<CreateProductAttributeOptionCommand>
{
    public CreateProductAttributeOptionValidator()
    {
        RuleFor(x => x.ProductAttributeId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0);
    }
}
