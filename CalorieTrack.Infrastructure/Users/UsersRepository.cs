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

    public async Task<User?> GetByIdAsync(string userId)
    {
      return await _context.Users.Where(user => user.Id == userId).FirstOrDefaultAsync();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}