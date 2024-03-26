using WebApplication3.Models;
using WebApplication3.Models.User;

namespace WebApplication3.Services
{
    public interface IAuthService
    {
        Task<UserModel> AuthAsync(string email, string password);
        Task<UserModel> RegisterAsync(UserModel user);
    }
}