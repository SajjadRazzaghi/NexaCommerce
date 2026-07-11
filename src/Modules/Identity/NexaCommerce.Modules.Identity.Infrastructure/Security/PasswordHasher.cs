using BCrypt.Net;

using NexaCommerce.Modules.Identity.Application.Abstractions.Security;

namespace NexaCommerce.Modules.Identity.Infrastructure.Security;

internal sealed class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string hash, string password)
        => BCrypt.Net.BCrypt.Verify(password, hash);
}
