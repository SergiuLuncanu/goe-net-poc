using GOE.Application.Common.Interfaces;

namespace GOE.API.Middleware
{
    public class JwtValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtService jwtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(' ').Last();
            var userIdentity = jwtService.ValidateToken(token);
            if (userIdentity != null)
            {
                context.Items["userIdentity"] = userIdentity;
            }
            await _next(context);
        }
    }

}
