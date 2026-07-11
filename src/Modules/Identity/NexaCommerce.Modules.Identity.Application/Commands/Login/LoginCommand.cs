using MediatR;

namespace NexaCommerce.Modules.Identity.Application.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<string>;