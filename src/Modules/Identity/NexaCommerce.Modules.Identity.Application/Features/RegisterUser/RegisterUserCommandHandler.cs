using MediatR;

using NexaCommerce.Modules.Identity.Application.Abstractions.Security;
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
    //  private readonly IUnitOfWork _unitOfWork;

    //public RegisterUserCommandHandler(
    //    IUserRepository users,
    //    IPasswordHasher passwordHasher,
    //    IUnitOfWork unitOfWork)
    //{
    //    _users = users;
    //    _passwordHasher = passwordHasher;
    //    _unitOfWork = unitOfWork;
    //}

    public async Task<Result<RegisterUserResponse>> Handle(
    RegisterUserCommand request,
    CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);

        var exists = await _users.GetByEmailAsync(
            email,
            cancellationToken);

        if (exists is not null)
        {
            return Result<RegisterUserResponse>.Failure(
                new Error(
                    "Identity.EmailExists",
                    "Email already exists"));
        }

        var fullName = FullName.Create(
            request.FirstName,
            request.LastName);

        var passwordHash = PasswordHash.Create(
     _passwordHasher.Hash(request.Password));

        var user = User.Create(
            email,
            fullName,
            passwordHash);

        await _users.AddAsync(user, cancellationToken);

        // بعداً UnitOfWork را اضافه می‌کنیم
        // await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<RegisterUserResponse>.Success(
            new RegisterUserResponse(user.Id));
    }
}
