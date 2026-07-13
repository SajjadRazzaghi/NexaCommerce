using FluentValidation;
namespace NexaCommerce.Modules.Identity.Application.Features.RefreshToken;

public sealed class RefreshTokenValidator
    : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty();
    }
}
