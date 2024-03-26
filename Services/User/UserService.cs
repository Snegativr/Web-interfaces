using WebApplication3.Models.User;
using WebApplication3.Services;

namespace WebApplication3.Services
{
    public class UserService : IUserService
    {
        private readonly List<UserModel> _userList;

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
                existingUser.FirstName = user.FirstName;
                existingUser.SecondName = user.SecondName;
                existingUser.Email = user.Email;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Password = user.Password;
                existingUser.LastLoginDate = user.LastLoginDate;
                existingUser.FailedLoginAttempts = user.FailedLoginAttempts;
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