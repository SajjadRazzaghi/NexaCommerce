using FluentValidation;

namespace NexaCommerce.Modules.Identity.Application.Features.ResetPassword;

public sealed class ResetPasswordValidator
    : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^09\d{9}$");

        RuleFor(x => x.Code)
            .Length(6);

        RuleFor(x => x.NewPassword)
            .MinimumLength(6);
    }
}
