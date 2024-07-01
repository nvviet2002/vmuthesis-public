using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_thesis.Context;
using BE_thesis.Model;
using BE_thesis.InputModel;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using BE_thesis.Data;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Identity;
using BE_thesis.Enum;
using Microsoft.AspNetCore.Authorization;
using MySqlX.XDevAPI.CRUD;
using BE_thesis.Services;
using BE_thesis.Filters;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{nameof(UserRole.Admin)}")]
    [Authorization]

    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IFileManager _fileManager;

        public UserController(AppDbContext context, UserManager<User> userManager, IFileManager fileManager)
        {
            _context = context;
            _userManager = userManager;
            _fileManager = fileManager;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users =  await _context.Users.ToListAsync();
            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", users));

        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", user));

            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", user));

        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutUser(string userId, ApiUserInput userInput)
        {
            if (userId != userInput.ID)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Bad Request", null));

            }

            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

            }

            user.UserName = userInput.Username ?? user.UserName;
            user.Name = userInput.Name??user.Name;
            user.Email = userInput.Email ?? user.Email;
            user.Address = userInput.Address ?? user.Address;
            user.Active = userInput.Active ?? user.Active;
            user.PhoneNumber = userInput.PhoneNumber ?? user.PhoneNumber;

            //handle Avatar
            if (userInput.Avatar != null)
            {
                string avatarName = $"{Guid.NewGuid()}" +
                    $"-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
                user.Avatar = await _fileManager.UploadFile(userInput.Avatar, avatarName, "Uploads/User/Avatar");
            }

            // remove roles
            var roles = await _userManager.GetRolesAsync(user);
            if(roles != null)
            {
                await _userManager.RemoveFromRolesAsync(user, roles);
            }
            //add new roles
            var newUserRoles = new List<string>();
            foreach(var userRole in userInput.UserRoles)
            {
                newUserRoles.Add(userRole.ToString());
            }
            await _userManager.AddToRolesAsync(user, newUserRoles);

            _context.Entry(user).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(userId))
                {
                    return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                       ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
                }
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", user));

        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostUser([FromForm] ApiUserInput userInput)
        {
            var newUser = new User();
            newUser.UserName = userInput.Username ?? "";
            newUser.Name = userInput.Name ?? "";
            newUser.Email = userInput.Email ?? "";
            newUser.Avatar = string.Empty;
            newUser.Address = userInput.Address ?? "";
            newUser.Active = userInput.Active ?? true;
            newUser.PhoneNumber = userInput.PhoneNumber ?? "";
            //handle Avatar
            if (userInput.Avatar == null)
            {
                newUser.Avatar = "";
            }
            else
            {
                string avatarName = $"{Guid.NewGuid()}" +
                    $"-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
                newUser.Avatar = await _fileManager.UploadFile(userInput.Avatar, avatarName, "Uploads/User/Avatar");
            }


            var userResult = await _userManager.CreateAsync(newUser, userInput.Password);
            if (userResult.Succeeded && userInput.UserRoles != null)
            {
                foreach (var userRole in userInput.UserRoles)
                {
                    await _userManager.AddToRoleAsync(newUser, userRole.ToString());
                }
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", newUser));

        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", user));

        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(string userName, string password)
        {

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

            }
            try
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, password);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                      ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", user));

        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public static string HashPassword(string password)
        {
            var encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

    }
}
