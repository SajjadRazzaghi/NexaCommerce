using Microsoft.EntityFrameworkCore;
using NexaCommerce.Modules.Identity.Domain.Entities;
using NexaCommerce.Modules.Identity.Domain.Repositories;

namespace NexaCommerce.Modules.Identity.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _context;

    public UserRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        User user,
        CancellationToken cancellationToken)
    {
        await _context.AddAsync(user, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(
                x => x.Email.Value == email,
                cancellationToken);
    }

    public async Task<User?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }
}