using WebApplication3.Models.User;

namespace WebApplication3.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsersAsync();
        Task AddUserAsync(UserModel user);
        Task UpdateUserAsync(int id, UserModel user);
        Task DeleteUserAsync(int id);
    }
}