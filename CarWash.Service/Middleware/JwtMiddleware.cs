using CarWash.Repository.Repositories.Users;
using CarWash.Service.Providers;
using Microsoft.AspNetCore.Http;
namespace CarWash.Service.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserRepository _userRepository, JwtGenerator jwtGenerator)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var validateTokenResult = await jwtGenerator.ValidateToken(token);
            if (!validateTokenResult.IsValid)
            {
                // Eğer token geçerli değilse, isteğe özel bir hata yanıtı dönebilirsiniz.
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid token");
                return;
            }

            context.Items["User"] = await _userRepository.GetByIdAsync(int.Parse(validateTokenResult.UserId));

            await _next(context);
        }

    }
}
