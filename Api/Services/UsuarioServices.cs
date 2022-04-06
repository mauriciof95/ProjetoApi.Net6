using Api.Configuration;
using Infrastructure.Data.Repository;
using Api.Data.Context;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.Enum;
using Models.Request;
using Models.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Api.Services
{
    public class UsuarioServices : BaseServices<Usuario, UsuarioRepository>
    {
        public PerfilServices _perfilServices;
        private TokenConfiguration _configToken;

        private const string DATE_FORMAT = "dd-MM-yyyy hh-mm-ss";

        public UsuarioServices(ApiContext context, TokenConfiguration configToken) : base(context) 
        { 
            _perfilServices = new PerfilServices(context);
            _configToken = configToken;
        }

        public UsuarioServices(ApiContext context) : base(context)
        {
            _repository = new UsuarioRepository(context);
            _perfilServices = new PerfilServices(context);
        }

        public async Task<TokenVM> ValidateUser(UserAuthRequest auth)
        {
            var user = await _repository.RetornarUsuarioPorNomeSenha(auth.username, auth.password);
            if (user == null) throw new Exception("Nome de usuario ou senha inválido.");

            var perfil = await _perfilServices.FindByID(user.perfil_id);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.nome),
                new Claim(CustomClaimTypes.Perfil, perfil.descricao)
            };

            var token = GenerateToken(claims);
            var refresh_token = GenerateRefreshToken();

            user.refresh_token = refresh_token;
            user.refresh_token_expiry_time = DateTime.Now.AddDays(_configToken.DaysToExpire);
            await Update(user, user.id);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configToken.Minutes);

            

            return new TokenVM
            {
                authenticated = true,
                created = createDate.ToString(DATE_FORMAT),
                expiration = expirationDate.ToString(DATE_FORMAT),
                token = token,
                refresh_token = refresh_token
            };
        }


        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configToken.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddMinutes(_configToken.Minutes);

            var options = new JwtSecurityToken(
                issuer: _configToken.Issuer,
                audience: _configToken.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: signinCredentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(options);

            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new Byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<TokenVM> ValidateCredentials(TokenVM tokenviewmodel)
        {
            var token = tokenviewmodel.token;
            var refresh_token = tokenviewmodel.refresh_token;

            var principal = GetPrincipalFromExpiredToken(token);

            var username = principal.Identity.Name;

            var user = await _repository.RetornarUsuarioPorNome(username);

            if (user == null 
                || user.refresh_token != refresh_token 
                || user.refresh_token_expiry_time <= DateTime.Now) return null;

            token = GenerateToken(principal.Claims);
            refresh_token = GenerateRefreshToken();

            user.refresh_token = refresh_token;
            user.refresh_token_expiry_time = DateTime.Now.AddDays(_configToken.DaysToExpire);
            await Update(user, user.id);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configToken.Minutes);

            return new TokenVM
            {
                authenticated = true,
                created = createDate.ToString(DATE_FORMAT),
                expiration = expirationDate.ToString(DATE_FORMAT),
                token = token,
                refresh_token = refresh_token
            };
        }

        public ClaimsPrincipal  GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configToken.Secret)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if(jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256, StringComparison.InvariantCulture))
            {
                throw new SecurityTokenException("Invalid Token");
            }

            return principal;
        }

        public async Task<bool> RevokeToken(string username)
        {
            var user = await _repository.RetornarUsuarioPorNome(username);
            if (user == null) return false;

            user.refresh_token = null;
            user.refresh_token_expiry_time = null;

            await Update(user, user.id);

            return true;
        }
    }
}
