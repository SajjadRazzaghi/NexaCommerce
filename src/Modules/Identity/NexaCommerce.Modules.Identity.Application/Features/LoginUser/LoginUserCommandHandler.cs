using MediatR;

using NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;
using NexaCommerce.Modules.Identity.Domain.Repositories;
using NexaCommerce.Modules.Identity.Domain.ValueObjects;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.LoginUser;

internal sealed class LoginUserCommandHandler
    : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserCommandHandler(
        IUserRepository users,
        IPasswordHasher passwordHasher)
    {
        _users = users;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<LoginUserResponse>> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _users.GetByEmailAsync(
            Email.Create(request.Email),
            cancellationToken);

        if (user is null)
        {
            return Result<LoginUserResponse>.Failure(
                new Error(
                    "Identity.InvalidCredentials",
                    "Invalid email or password."));
        }

        var isValid = _passwordHasher.Verify(
            request.Password,
            user.PasswordHash.Value);

        if (!isValid)
        {
            return Result<LoginUserResponse>.Failure(
                new Error(
                    "Identity.InvalidCredentials",
                    "Invalid email or password."));
        }

        return Result<LoginUserResponse>.Success(
            new LoginUserResponse(user.Id));
    }
}
