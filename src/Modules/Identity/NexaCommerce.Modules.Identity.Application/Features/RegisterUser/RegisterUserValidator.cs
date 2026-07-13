using FluentValidation;

namespace NexaCommerce.Modules.Identity.Application.Features.RegisterUser;

public sealed class RegisterUserValidator
    : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^09\d{9}$")
            .WithMessage("Phone number is invalid.");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);

        //RuleFor(x => x.Email)
        //    .EmailAddress()
        //    .When(x => !string.IsNullOrWhiteSpace(x.Email));
    }
}
