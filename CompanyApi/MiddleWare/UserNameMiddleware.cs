using CompanyApi.Controllers;
using System.Security.Claims;

namespace CompanyApi.MiddleWare
{
    public class UserNameMiddleware
    {
        private readonly RequestDelegate _next;

        public UserNameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, ILogger<AdminController> _logger)
        {
            var username = httpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            //httpContext.Items["UserName"] = username;
            _logger.LogInformation("{UserName}",username);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UserNameMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserNameMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserNameMiddleware>();
        }
    }
}
