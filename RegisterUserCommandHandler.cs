using MediatR;

namespace NexaCommerce.Modules.Identity.Application.Commands.RegisterUser;

public sealed class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}