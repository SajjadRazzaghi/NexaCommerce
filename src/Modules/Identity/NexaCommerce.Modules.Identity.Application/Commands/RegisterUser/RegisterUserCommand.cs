using MediatR;

namespace NexaCommerce.Modules.Identity.Application.Commands.RegisterUser;

public sealed record RegisterUserCommand(
    string FirstName,
    string LastName,
   string PhoneNumber,
    string Password
) : IRequest<Guid>;
