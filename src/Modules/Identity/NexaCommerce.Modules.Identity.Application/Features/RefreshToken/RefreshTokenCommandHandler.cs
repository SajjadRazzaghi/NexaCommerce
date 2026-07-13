using MediatR;


using NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;
using NexaCommerce.Modules.Identity.Domain.Repositories;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.RefreshToken;

internal sealed class RefreshTokenCommandHandler
    : IRequestHandler<RefreshTokenCommand, Result<RefreshTokenResponse>>
{
    private readonly IUserRepository _users;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public RefreshTokenCommandHandler(
        IUserRepository users,
        IJwtProvider jwtProvider,
        IUnitOfWork unitOfWork)
    {
        _users = users;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RefreshTokenResponse>> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await _users.GetByRefreshTokenAsync(
                request.RefreshToken,
                cancellationToken);

        if (user is null)
        {
            return Result<RefreshTokenResponse>.Failure(
                new Error(
                    "Identity.InvalidRefreshToken",
                    "Refresh token is invalid."));
        }

        if (user.RefreshTokenExpiresOnUtc < DateTime.UtcNow)
        {
            return Result<RefreshTokenResponse>.Failure(
                new Error(
                    "Identity.RefreshExpired",
                    "Refresh token expired."));
        }

        var accessToken =
            _jwtProvider.Generate(user.Id);

        var refreshToken =
            _jwtProvider.GenerateRefreshToken();

        user.SetRefreshToken(
            refreshToken,
            DateTime.UtcNow.AddDays(30));

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<RefreshTokenResponse>.Success(
            new RefreshTokenResponse(
                accessToken,
                refreshToken));
    }
}
