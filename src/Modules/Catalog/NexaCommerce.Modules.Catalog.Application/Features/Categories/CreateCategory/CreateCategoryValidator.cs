using FluentValidation;

namespace NexaCommerce.Modules.Catalog.Application.Features.Categories.CreateCategory;

public sealed class CreateCategoryValidator
    : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(250);
    }
}
