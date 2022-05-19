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
        private PerfilServices _perfilServices;

        public CustomAuthorizeFilter(Claim claim, PerfilServices services)
        {
            _claim = claim;
            _perfilServices = services;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claimPerfil = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == _claim.Type);

            if(claimPerfil == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            var hasPermission = _perfilServices.RoleHasPermission(claimPerfil.Value, _claim.Value);

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
