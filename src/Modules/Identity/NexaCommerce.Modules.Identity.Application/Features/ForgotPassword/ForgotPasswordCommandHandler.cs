using MediatR;

using NexaCommerce.Modules.Identity.Domain.Repositories;
using NexaCommerce.Modules.Identity.Domain.ValueObjects;
using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.ForgotPassword;

internal sealed class ForgotPasswordCommandHandler
    : IRequestHandler<ForgotPasswordCommand, Result>
{
    private readonly IUserRepository _users;
    private readonly IUnitOfWork _unitOfWork;

    public ForgotPasswordCommandHandler(
        IUserRepository users,
        IUnitOfWork unitOfWork)
    {
        _users = users;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        ForgotPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await _users.GetByPhoneNumberAsync(
                PhoneNumber.Create(request.PhoneNumber),
                cancellationToken);

        if (user is null)
        {
            return Result.Success();
        }

        var code = Random.Shared.Next(100000, 999999).ToString();

        user.SetPasswordResetCode(
            code,
            DateTime.UtcNow.AddMinutes(2));

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // TODO:
        // ارسال پیامک

        return Result.Success();
    }
}
