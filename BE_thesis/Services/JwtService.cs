using BE_thesis.Context;
using BE_thesis.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_thesis.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public JwtService(IConfiguration configuration
            , AppDbContext context
            , UserManager<User> userManager)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
        }
        public async Task<string> CreateJwtAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("UserName", user.UserName),
                new Claim("UserId", user.Id.ToString() )

            };
            if (!roles.IsNullOrEmpty())
            {
                foreach (var role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<JwtSecurityToken?> DecodeJwtAsync(string jwt)
        {
            var secretKey = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]);
            var jwtTokenHander = new JwtSecurityTokenHandler();
            var tokenValidateParam = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:ValidAudience"],
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateLifetime = false,
            };
            var tokenVertication = await jwtTokenHander.ValidateTokenAsync(jwt, tokenValidateParam);
            var jwtSecurityToken = tokenVertication.SecurityToken as JwtSecurityToken;
            return jwtSecurityToken;
        }

    }
}
