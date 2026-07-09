using Microsoft.AspNetCore.Identity;
using NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;

namespace NexaCommerce.Modules.Identity.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher
{
    private readonly Microsoft.AspNetCore.Identity.PasswordHasher<object> _hasher = new();

    public string Hash(string password)
    {
        return _hasher.HashPassword(new object(), password);
    }

    public bool Verify(string password, string hash)
    {
        var result = _hasher.VerifyHashedPassword(new object(), hash, password);

        return result == PasswordVerificationResult.Success
            || result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}