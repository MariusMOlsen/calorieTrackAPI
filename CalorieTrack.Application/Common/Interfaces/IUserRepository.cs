using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.Common.Interfaces;

public interface IUserRepository
{ 
    Task AddUserASync(User user);
    Task<bool> ExistsByEmailAsync(string email);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByGoogleUserIdAsync(string userId);
    
    Task<User?> GetByIdAsync(Guid id);
    Task UpdateAsync(User user);
}