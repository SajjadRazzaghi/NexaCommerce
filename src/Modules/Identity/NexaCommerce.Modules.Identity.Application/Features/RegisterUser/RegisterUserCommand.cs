using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.RegisterUser;

public sealed record RegisterUserCommand(
    string PhoneNumber,
    string FirstName,
    string LastName,
    string Password)
    : IRequest<Result<RegisterUserResponse>>;
