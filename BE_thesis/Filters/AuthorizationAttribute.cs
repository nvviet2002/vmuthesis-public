using BE_thesis.Context;
using BE_thesis.Data;
using BE_thesis.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BE_thesis.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private AppDbContext _context;
        private IJwtService _jwtService;

        private List<string> Permissions { get; set; } = new List<string>();
        public AuthorizationAttribute(params string[] permissions)
        {
            Permissions.AddRange(permissions);
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext filterContext)
        {

            if (filterContext != null)
            {
                _context = filterContext.HttpContext.RequestServices.GetService<AppDbContext>();
                _jwtService = filterContext.HttpContext.RequestServices.GetService<IJwtService>();

                filterContext.HttpContext.Request.Headers.TryGetValue("Authorization", out var headerAuth);
                var jwt = headerAuth.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                if (jwt == null)
                {
                    filterContext.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    filterContext.HttpContext.Response.CompleteAsync();
                }
                else
                {
                    var jwtSecure = await _jwtService.DecodeJwtAsync(jwt);
                    var userId = jwtSecure.Claims.FirstOrDefault(q => q.Type == "UserId").Value;
                    var user = await _context.Users.FindAsync(userId);
                    if (user == null)
                    {
                        filterContext.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                        filterContext.HttpContext.Response.CompleteAsync();
                    }
                    else
                    {
                        if (!user.Jwt.Equals(jwt))
                        {
                            filterContext.HttpContext.Response.StatusCode = (int)StatusCodes.Status401Unauthorized;
                            filterContext.HttpContext.Response.CompleteAsync();
                        }
                    }
                }
            }
        }
    }
}
