using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication3.Models.Auth
{
    public class AuthModel
    {
        public const string ISSUER = "Server";
        public const string AUDIENCE = "Client";
        const string KEY = "JwtSecretCodeForLR8";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}