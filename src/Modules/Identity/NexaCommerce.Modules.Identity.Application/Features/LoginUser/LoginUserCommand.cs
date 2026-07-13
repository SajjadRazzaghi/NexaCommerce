using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.LoginUser;

public sealed record LoginUserCommand(
    string PhoneNumber,
    string Password)
    : IRequest<Result<LoginUserResponse>>;
