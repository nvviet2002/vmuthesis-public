using BE_thesis.Model;
using System.IdentityModel.Tokens.Jwt;

namespace BE_thesis.Services
{
    public interface IJwtService
    {
        Task<string> CreateJwtAsync(User user);
        Task<JwtSecurityToken?> DecodeJwtAsync(string jwt);
    }
}
