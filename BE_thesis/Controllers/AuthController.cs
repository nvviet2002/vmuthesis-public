using BE_thesis.Context;
using BE_thesis.Data;
using BE_thesis.Filters;
using BE_thesis.InputModel;
using BE_thesis.Model;
using BE_thesis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using static QRCoder.PayloadGenerator;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthController(AppDbContext context, UserManager<User> userManager
            ,SignInManager<User> signInManager, IJwtService jwtService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ApiLoginInput userInput)
        {
            var result = await _signInManager.PasswordSignInAsync(userInput.UserName, userInput.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userInput.UserName);
                var jwt = await _jwtService.CreateJwtAsync(user);
                //store jwt
                user.Jwt = jwt;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success"
                    , new
                    {
                        Token = jwt,
                        User = user
                    }));
            }
            else
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Username or password is wrong", null));

            }

            
        }

        [HttpGet("profile")]
        [Authorize]
        [Authorization]

        public async Task<IActionResult> GetProfile()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out var headerAuth);
            var jwt = headerAuth.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
            if (jwt == null)
            {
                return Unauthorized(ApiResponse.Instance.Response(StatusCodes.Status401Unauthorized, "Jwt is missing", null));
            }
            else
            {
                var jwtSecure = await _jwtService.DecodeJwtAsync(jwt);
                var userId = jwtSecure.Claims.FirstOrDefault(q => q.Type == "UserId").Value;
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "User not found", null));
                }
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success"
                    , new
                    {
                        ID = user.Id,
                        UserName = user.UserName,
                        Name = user.Name,
                        Adress = user.Address,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        Avatar = user.Avatar,
                        Active = user.Active,
                        Roles = roles,
                    }));
            }

        }

    }
}
