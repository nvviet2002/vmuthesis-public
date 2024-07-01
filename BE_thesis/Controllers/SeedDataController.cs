using BE_thesis.Context;
using BE_thesis.Data;
using BE_thesis.Enum;
using BE_thesis.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedDataController(AppDbContext context, RoleManager<IdentityRole>  roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> SeedRoles()
        {

            foreach (var name in typeof(UserRole).GetEnumNames())
            {
                var role = await _roleManager.FindByNameAsync(name);
                if(role == null)
                {
                    var newRole = new IdentityRole(name);
                    await _roleManager.CreateAsync(newRole);
                }
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", null));

        }
    }
}
