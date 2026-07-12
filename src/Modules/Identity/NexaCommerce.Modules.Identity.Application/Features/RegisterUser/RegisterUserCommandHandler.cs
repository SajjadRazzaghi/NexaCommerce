using MediatR;

using NexaCommerce.SharedKernel.Abstractions;
using NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;
using NexaCommerce.Modules.Identity.Domain.Entities;
using NexaCommerce.Modules.Identity.Domain.Repositories;
using NexaCommerce.Modules.Identity.Domain.ValueObjects;
using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.RegisterUser;

internal sealed class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, Result<RegisterUserResponse>>
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        IUserRepository users,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _users = users;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<RegisterUserResponse>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var existing =
     await _users.GetByPhoneNumberAsync(
         PhoneNumber.Create(request.PhoneNumber),
         cancellationToken);

        if (existing is not null)
        {
            return Result<RegisterUserResponse>.Failure(
                new Error(
                    "Identity.PhoneExists",
                    "Phone already exists."));
        }

        var user = User.Create(
           PhoneNumber.Create(request.PhoneNumber),
            FullName.Create(request.FirstName, request.LastName),
            new PasswordHash(
                _passwordHasher.Hash(request.Password)));

        await _users.AddAsync(user, cancellationToken);

        // ذخیره در دیتابیس
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<RegisterUserResponse>.Success(
            new RegisterUserResponse(user.Id));
    }
}
