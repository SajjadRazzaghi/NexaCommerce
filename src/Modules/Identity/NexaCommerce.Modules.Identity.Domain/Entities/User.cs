using NexaCommerce.Modules.Identity.Domain.Enums;
using NexaCommerce.Modules.Identity.Domain.ValueObjects;

namespace NexaCommerce.Modules.Identity.Domain.Entities;



public sealed class User
{
    public Guid Id { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; } = null!;

    public FullName FullName { get; private set; } = null!;

    public PasswordHash PasswordHash { get; private set; } = null!;
    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ModifiedOnUtc { get; private set; }
    public UserStatus Status
    {
        get; private set;
    }

    private User()
    {
    }

    private User(
     Guid id,
     PhoneNumber phoneNumber,
     FullName fullName,
     PasswordHash passwordHash)
    {
        Id = id;
        PhoneNumber = phoneNumber; 
        FullName = fullName;
        PasswordHash = passwordHash;
        Status = UserStatus.Active;
    }
    public static User Create(
    PhoneNumber phoneNumber,
    FullName fullName,
    PasswordHash passwordHash)
    {
        return new User(
            Guid.NewGuid(),
            phoneNumber,
            fullName,
            passwordHash);
    }
}
