using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        public string SecondName { get; set; }

        [Required]
        [EmailAddress()]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }

        public DateTime LastLoginDate { get; set; }

        public int FailedLoginAttempts { get; set; }
    }
}