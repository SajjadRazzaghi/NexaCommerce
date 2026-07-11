using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.RegisterUser;

internal sealed class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, Result<RegisterUserResponse>>
{
    public async Task<Result<RegisterUserResponse>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        // در Commit بعد Repository و PasswordHasher را اضافه می‌کنیم

        var response = new RegisterUserResponse(Guid.NewGuid());

        return await Task.FromResult(Result<RegisterUserResponse>.Success(response));
    }
}
