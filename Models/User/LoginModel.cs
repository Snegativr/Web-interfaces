using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.User
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}