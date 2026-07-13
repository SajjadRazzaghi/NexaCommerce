using NexaCommerce.Modules.Identity.Domain.Entities;
using NexaCommerce.Modules.Identity.Domain.ValueObjects;

namespace NexaCommerce.Modules.Identity.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

   


    Task AddAsync(
        User user,
        CancellationToken cancellationToken = default);
    
    Task<User?> GetByResetCodeAsync(
    string code,
    CancellationToken cancellationToken = default);
    Task<User?> GetByPhoneNumberAsync(
    PhoneNumber phoneNumber,
    CancellationToken cancellationToken = default);
    Task<User?> GetByRefreshTokenAsync(
    string refreshToken,
    CancellationToken cancellationToken = default);

}
