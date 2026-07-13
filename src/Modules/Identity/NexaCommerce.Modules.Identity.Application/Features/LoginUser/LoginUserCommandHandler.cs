using MediatR;

using NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;
using NexaCommerce.Modules.Identity.Domain.Repositories;
using NexaCommerce.Modules.Identity.Domain.ValueObjects;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.LoginUser;

internal sealed class LoginUserCommandHandler
    : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserCommandHandler(
       IUserRepository users,
       IPasswordHasher passwordHasher,
       IJwtProvider jwtProvider,
       IUnitOfWork unitOfWork)
    {
        _users = users;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<LoginUserResponse>> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await _users.GetByPhoneNumberAsync(
                PhoneNumber.Create(request.PhoneNumber),
                cancellationToken);

        if (user is null)
        {
            return Result<LoginUserResponse>.Failure(
                new Error(
                    "Identity.InvalidCredentials",
                    "نام کاربری یا رمز اشتباه است."));
        }

        if (!_passwordHasher.Verify(
            request.Password,
            user.PasswordHash.Value))
        {
            return Result<LoginUserResponse>.Failure(
                new Error(
                    "Identity.InvalidCredentials",
                    "نام کاربری یا رمز اشتباه است."));
        }

        var token =
            _jwtProvider.Generate(user.Id);
        var refreshToken =
    _jwtProvider.GenerateRefreshToken();

        user.SetRefreshToken(
            refreshToken,
            DateTime.UtcNow.AddDays(30));

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<LoginUserResponse>.Success(
     new LoginUserResponse(
         user.Id,
         token,
         refreshToken));
    }
}
