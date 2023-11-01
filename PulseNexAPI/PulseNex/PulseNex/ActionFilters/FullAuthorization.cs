using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PulseNex.Helpers;

namespace PulseNex.ActionFilters
{
    public class FullAuthorization : IAuthorizationFilter
    {
        IHttpContextAccessor HttpContextAccessor { get; set; }
        public FullAuthorization(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var accessToken = HttpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(accessToken))
            {
                context.Result = new ForbidResult();
                return;
            }

            accessToken = accessToken.ToString().Replace("Bearer ", "");
            var tokenFlag = AuthHelper.ValidateToken(accessToken);

            if (!tokenFlag)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }

    public class FullAuthorizationAttribute : TypeFilterAttribute
    {
        public FullAuthorizationAttribute() : base(typeof(FullAuthorization))
        {
            Arguments = new object[] { };
        }
    }
}
