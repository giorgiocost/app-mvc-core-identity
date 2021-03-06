using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace app_mvc_core_identity.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(c => c.Type == claimName && 
                c.Value.Contains(claimValue));
        }

    }

    public class ClaimAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimsFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue)};
        }
    }

    public class RequisitoClaimsFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public RequisitoClaimsFilter(Claim claim)
        {
            _claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // mudando redirecionamento 
            if(context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new 
                        { 
                            area = "Identity",
                            page = "/Account/Login",
                            ReturnUrl = context.HttpContext.Request.Path.ToString()
                        }
                    )
                );
                return;
            }
            if(!CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }

    }
}