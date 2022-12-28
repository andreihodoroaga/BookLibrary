using BookLibraryBackend.Models;
using BookLibraryBackend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookLibraryBackend.Helpers.Attributes
{
    public class AuthorizationAttribute: Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public AuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new { Message = "Unauthorized" })
            { StatusCode = StatusCodes.Status401Unauthorized };


            if(_roles == null)
            {
                context.Result = unauthorizedStatusObject;  
            }

            var user = (User)context.HttpContext.Items["User"];
            if(user == null || !_roles.Contains(user.Role))
            {
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
