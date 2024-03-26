namespace WebApplication3.Models.User
{
    public class UserData
    {
        public static List<UserModel> Users { get; } = new List<UserModel>
        {
            new UserModel
            {
                Id = 1,
                FirstName = "John",
                SecondName = "Doe",
                Email = "john@example.com",
                DateOfBirth = new DateTime(1900, 3, 19),
                Password = "RamRam",
                LastLoginDate = DateTime.Now.AddDays(-199),
                FailedLoginAttempts = 13
            },
            new UserModel
            {
                Id = 2,
                FirstName = "Maria",
                SecondName = "Smith",
                Email = "maria@example.com",
                DateOfBirth = new DateTime(200, 11, 25),
                Password = "DogIAm",
                LastLoginDate = DateTime.Now.AddDays(-3333),
                FailedLoginAttempts = 1
            },
            new UserModel
            {
                Id = 3,
                FirstName = "Max",
                SecondName = "Mitchell",
                Email = "max@example.com",
                DateOfBirth = new DateTime(2314, 5, 5),
                Password = "qwerty123",
                LastLoginDate = new DateTime(2022,1,14),
                FailedLoginAttempts = 0
            },
        };
    }
}
