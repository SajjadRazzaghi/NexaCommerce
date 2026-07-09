namespace NexaCommerce.Modules.Identity.Application.Interfaces;

public interface IJwtProvider
{
    string Generate(Guid userId);
}