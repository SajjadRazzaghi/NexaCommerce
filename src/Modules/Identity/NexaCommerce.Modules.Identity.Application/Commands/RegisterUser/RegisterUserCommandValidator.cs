using FluentValidation;

namespace NexaCommerce.Modules.Identity.Application.Commands.RegisterUser;

public sealed class RegisterUserCommandValidator
    : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^09\d{9}$")
            .WithMessage("شماره موبایل معتبر نیست.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}
