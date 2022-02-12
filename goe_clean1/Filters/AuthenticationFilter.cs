using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {

        private readonly string _role;

        public AuthenticationFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var userIdentity = (UserIdentity?)context.HttpContext.Items["userIdentity"];
            if (userIdentity == null || !_role.Contains(userIdentity.Role) )
            {
                context.Result = new JsonResult(new {message ="Unauthorized"}) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
