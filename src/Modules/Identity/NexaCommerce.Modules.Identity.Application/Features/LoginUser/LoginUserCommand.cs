using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.LoginUser;

public sealed record LoginUserCommand(
    string Email,
    string Password)
    : IRequest<Result<LoginUserResponse>>;
