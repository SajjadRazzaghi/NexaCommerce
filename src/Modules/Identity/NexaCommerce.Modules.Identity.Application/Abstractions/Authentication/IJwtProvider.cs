namespace NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    string Generate(Guid userId);

    string GenerateRefreshToken();
}
