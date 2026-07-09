namespace NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    string GenerateToken(Guid userId, string email);
}