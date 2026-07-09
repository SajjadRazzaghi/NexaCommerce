using NexaCommerce.Modules.Identity.Domain.Enums;
using NexaCommerce.Modules.Identity.Domain.ValueObjects;

namespace NexaCommerce.Modules.Identity.Domain.Entities;



public sealed class User
{
    public Guid Id { get; private set; }

    public Email Email { get; private set; } = null!;

    public FullName FullName { get; private set; } = null!;

    public PasswordHash PasswordHash { get; private set; } = null!;

    public UserStatus Status
    {
        get; private set;
    }

    private User()
    {
    }

    private User(
     Guid id,
     Email email,
     FullName fullName,
     PasswordHash passwordHash)
    {
        Id = id;
        Email = email;
        FullName = fullName;
        PasswordHash = passwordHash;
        Status = UserStatus.Active;
    }
    public static User Create(
    Email email,
    FullName fullName,
    PasswordHash passwordHash)
    {
        return new User(
            Guid.NewGuid(),
            email,
            fullName,
            passwordHash);
    }
}