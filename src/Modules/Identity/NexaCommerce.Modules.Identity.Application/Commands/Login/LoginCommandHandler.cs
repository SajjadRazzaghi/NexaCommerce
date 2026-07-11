using MediatR;

namespace NexaCommerce.Modules.Identity.Application.Commands.Login;

public sealed class LoginCommandHandler
    : IRequestHandler<LoginCommand, string>
{
    public Task<string> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
