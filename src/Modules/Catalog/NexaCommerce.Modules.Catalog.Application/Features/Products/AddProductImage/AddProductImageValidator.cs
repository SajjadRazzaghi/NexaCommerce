using FluentValidation;

namespace NexaCommerce.Modules.Catalog.Application.Features.Products.AddProductImage;

public sealed class AddProductImageValidator
    : AbstractValidator<AddProductImageCommand>
{
    public AddProductImageValidator()
    {
        RuleFor(x => x.ImageUrl)
            .NotEmpty();

        RuleFor(x => x.ProductId)
            .NotEmpty();
    }
}
