using FluentValidation;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.CreateProduct;

public sealed class CreateProductValidator
    : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty();

        RuleFor(x => x.BrandId)
            .NotEmpty();
    }
}
