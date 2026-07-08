using EPOS.Application.Common.Interfaces;
using EPOS.Domain.Entities;
using EPOS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EPOS.Persistence.Repositories.Authentication;

public class UserRepository : IUserRepository
{
    private readonly EPOSDbContext _context;

    public UserRepository(EPOSDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetByMobileAsync(string mobile)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.MobileNumber == mobile);
    }

    public async Task<User?> GetByEmailOrMobileAsync(string loginId)
    {
        return await _context.Users
            .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x =>
                x.Email == loginId ||
                x.MobileNumber == loginId);

    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .OrderBy(x => x.FirstName)
            .ToListAsync();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users
            .AnyAsync(x => x.Email == email);
    }

    public async Task<bool> MobileExistsAsync(string mobile)
    {
        return await _context.Users
            .AnyAsync(x => x.MobileNumber == mobile);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task AddUserRoleAsync(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}