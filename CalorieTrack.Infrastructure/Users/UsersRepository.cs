using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Infrastructure.Users;

public class UserRepository : IUserRepository
{

    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public async Task  AddUserASync(User user)
    {
     await _context.Users.AddAsync(user);
    }

    public Task<bool> ExistsByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByGoogleUserIdAsync(string userId)
    {
      return await _context.Users.Where(user => user.GoogleUserId == userId).FirstOrDefaultAsync();
    }
    
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
    

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}