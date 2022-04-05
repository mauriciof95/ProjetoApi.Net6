using Api.Repository;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models.Enum;
using System.Security.Claims;

namespace Api.Helpers
{
    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        readonly Claim _claim;
        private ApiContext _apiContext;

        public CustomAuthorizeFilter(Claim claim, ApiContext apiContext)
        {
            _claim = claim;
            _apiContext = apiContext;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claimPerfil = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == _claim.Type);

            if(claimPerfil == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            var hasPermission = new PerfilServices(_apiContext).RoleHasPermission(claimPerfil.Value, _claim.Value);

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }

    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(string claimValue) : base(typeof(CustomAuthorizeFilter))
        {
            Arguments = new object[] { new Claim(CustomClaimTypes.Perfil, claimValue) };
        }
    }
}
