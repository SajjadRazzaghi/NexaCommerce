using FluentValidation;

namespace NexaCommerce.Modules.Catalog.Application.Features.Brands.CreateBrand;

public sealed class CreateBrandValidator
    : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(250);
    }
}
