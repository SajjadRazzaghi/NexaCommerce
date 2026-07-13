using FluentValidation;

namespace NexaCommerce.Modules.Catalog.Application.Features.ProductAttributes.CreateProductAttribute;

public sealed class CreateProductAttributeValidator
    : AbstractValidator<CreateProductAttributeCommand>
{
    public CreateProductAttributeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}
