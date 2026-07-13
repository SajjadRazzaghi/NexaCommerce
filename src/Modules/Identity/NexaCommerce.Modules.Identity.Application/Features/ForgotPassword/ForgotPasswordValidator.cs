using FluentValidation;

namespace NexaCommerce.Modules.Identity.Application.Features.ForgotPassword;

public sealed class ForgotPasswordValidator
    : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^09\d{9}$");
    }
}
