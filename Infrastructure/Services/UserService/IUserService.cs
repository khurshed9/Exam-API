using examAPI.Models.User;

namespace examAPI.Infrastructure.Services.UserService;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    
    Task<User> GetUserByUserName(string userName);
    
    Task<bool> CreateUser(User user);
    
    Task<bool> UpdateUser(User user);
    
    Task<bool> DeleteUser(string userName);
}