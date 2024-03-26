using WebApplication3.Models;
using WebApplication3.Models.User;

namespace WebApplication3.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<UserModel> _users;

        public AuthService()
        {
            _users = UserData.Users;
        }

        public async Task<UserModel> AuthAsync(string email, string password)
        {
            var user = _users.SingleOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }

        public async Task<UserModel> RegisterAsync(UserModel newUser)
        {
            if (_users.Any(u => u.Email != newUser.Email))
            {
                _users.Add(newUser);
                return newUser;
            }
            return null;
        }
    }
}