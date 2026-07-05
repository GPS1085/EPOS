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

            .FirstOrDefaultAsync(x =>

                x.Email == loginId ||

                x.MobileNumber == loginId);

    }



    public async Task AddAsync(User user)

    {

        await _context.Users.AddAsync(user);

    }



    public async Task SaveChangesAsync()

    {

        await _context.SaveChangesAsync();

    }

}