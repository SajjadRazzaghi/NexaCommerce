using MediatR;

namespace NexaCommerce.Modules.Identity.Application.Commands.RegisterUser;

public sealed class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, Guid>
{
    public Task<Guid> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
