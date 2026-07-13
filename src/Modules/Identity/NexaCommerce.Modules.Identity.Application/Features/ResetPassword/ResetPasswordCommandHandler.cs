using MediatR;

using NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;
using NexaCommerce.Modules.Identity.Domain.Repositories;
using NexaCommerce.Modules.Identity.Domain.ValueObjects;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.ResetPassword;

internal sealed class ResetPasswordCommandHandler
    : IRequestHandler<ResetPasswordCommand, Result>
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public ResetPasswordCommandHandler(
        IUserRepository users,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _users = users;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        ResetPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await _users.GetByPhoneNumberAsync(
                PhoneNumber.Create(request.PhoneNumber),
                cancellationToken);

        if (user is null)
        {
            return Result.Failure(
                new Error(
                    "Identity.UserNotFound",
                    "کاربر یافت نشد."));
        }

        if (!user.IsPasswordResetCodeValid(request.Code))
        {
            return Result.Failure(
                new Error(
                    "Identity.InvalidCode",
                    "کد بازیابی نامعتبر است."));
        }

        user.ChangePassword(
            new PasswordHash(
                _passwordHasher.Hash(request.NewPassword)));

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
