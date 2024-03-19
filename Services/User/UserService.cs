using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Services
{
    public class UserService : IUserService
    {
        private readonly List<UserModel> _userList;

        public UserService()
        {
            _userList = new List<UserModel>
            {
                new UserModel { Id = 1, Username = "JohnDoe", Email = "john.doe@example.com", DateOfBirth = new DateTime(1987, 5, 15), Location = "New York City" },
                new UserModel { Id = 2, Username = "JaneSmith", Email = "jane.smith@example.com", DateOfBirth = new DateTime(1985, 3, 20), Location = "London" },
                new UserModel { Id = 3, Username = "MikeJohnson", Email = "mike.johnson@example.com", DateOfBirth = new DateTime(1990, 10, 8), Location = "Paris" },
                new UserModel { Id = 4, Username = "EmilyBrown", Email = "emily.brown@example.com", DateOfBirth = new DateTime(1982, 8, 25), Location = "Tokyo" },
                new UserModel { Id = 5, Username = "AlexWilliams", Email = "alex.williams@example.com", DateOfBirth = new DateTime(1993, 11, 12), Location = "Sydney" },
                new UserModel { Id = 6, Username = "JessicaLee", Email = "jessica.lee@example.com", DateOfBirth = new DateTime(1988, 7, 30), Location = "Berlin" },
                new UserModel { Id = 7, Username = "DavidMartinez", Email = "david.martinez@example.com", DateOfBirth = new DateTime(1979, 9, 18), Location = "Moscow" },
                new UserModel { Id = 8, Username = "EmmaGarcia", Email = "emma.garcia@example.com", DateOfBirth = new DateTime(1991, 6, 6), Location = "Beijing" },
                new UserModel { Id = 9, Username = "DanielLopez", Email = "daniel.lopez@example.com", DateOfBirth = new DateTime(1986, 4, 3), Location = "Rio de Janeiro" },
                new UserModel { Id = 10, Username = "OliviaTaylor", Email = "olivia.taylor@example.com", DateOfBirth = new DateTime(1977, 12, 24), Location = "Toronto" }
            };
        }

        public Task<List<UserModel>> GetUsersAsync()
        {
            return Task.FromResult(_userList);
        }

        public Task AddUserAsync(UserModel user)
        {
            _userList.Add(user);
            return Task.CompletedTask;
        }

        public Task UpdateUserAsync(int id, UserModel user)
        {
            var existingUser = _userList.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Location = user.Location;
            }
            return Task.CompletedTask;
        }

        public Task DeleteUserAsync(int id)
        {
            var userToDelete = _userList.FirstOrDefault(u => u.Id == id);
            if (userToDelete != null)
            {
                _userList.Remove(userToDelete);
            }
            return Task.CompletedTask;
        }
    }
}