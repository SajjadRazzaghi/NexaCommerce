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
    public string? RefreshToken { get; private set; }

    public DateTime? RefreshTokenExpiresOnUtc { get; private set; }

    public string? PasswordResetCode { get; private set; }

    public DateTime? PasswordResetCodeExpiresOnUtc { get; private set; }
    

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
    public void SetRefreshToken(
    string refreshToken,
    DateTime expiresOnUtc)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiresOnUtc = expiresOnUtc;
    }
    public void SetPasswordResetCode(
    string code,
    DateTime expiresOnUtc)
    {
        PasswordResetCode = code;
        PasswordResetCodeExpiresOnUtc = expiresOnUtc;
    }

    public void ClearPasswordResetCode()
    {
        PasswordResetCode = null;
        PasswordResetCodeExpiresOnUtc = null;
    }
    public bool IsPasswordResetCodeValid(
    string code)
    {
        return PasswordResetCode == code &&
               PasswordResetCodeExpiresOnUtc >= DateTime.UtcNow;
    }

    public void ChangePassword(
    PasswordHash passwordHash)
    {
        PasswordHash = passwordHash;

        PasswordResetCode = null;

        PasswordResetCodeExpiresOnUtc = null;
    }

   
}
