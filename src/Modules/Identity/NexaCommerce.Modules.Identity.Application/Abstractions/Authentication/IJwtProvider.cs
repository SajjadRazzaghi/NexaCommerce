using NexaCommerce.Modules.Identity.Domain.Entities;

namespace NexaCommerce.Modules.Identity.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    string Generate(User user);
}
