using FluentValidation;

namespace NexaCommerce.Modules.Identity.Application.Features.LoginUser;

public sealed class LoginUserValidator
    : AbstractValidator<LoginUserCommand>
{
    public LoginUserValidator()
    {
        // اعتبارسنجی برای PhoneNumber
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required")
            .MinimumLength(10)
            .WithMessage("Phone number must be at least 10 digits")
            .MaximumLength(15)
            .WithMessage("Phone number must not exceed 15 digits")
            .Matches(@"^[0-9]+$")
            .WithMessage("Phone number must contain only digits");

        // اعتبارسنجی پسورد
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters")
            .MaximumLength(100)
            .WithMessage("Password must not exceed 100 characters");
    }
}
