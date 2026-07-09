namespace NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;

public interface ICurrentUser
{
    Guid? UserId { get; }

    string? Email { get; }

    bool IsAuthenticated { get; }
}