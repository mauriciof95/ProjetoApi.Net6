using Api.Configuration;
using Api.Helpers;
using Api.Repository;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enum;
using Models.Request;
using Models.ViewModel;

namespace Api.Controllers
{
    [Route("[controller]")]
    [Authorize("Bearer")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioServices _services;
        public UsuarioController(ApiContext context, TokenConfiguration tokenConfig) => _services = new UsuarioServices(context, tokenConfig);

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthRequest auth)
        {
            try
            {
                if (auth == null) return BadRequest("Invalid request");
                var token = await _services.ValidateUser(auth);
                if(token == null) return Unauthorized();
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenVM tokenviewmodel)
        {
            try
            {
                if (tokenviewmodel == null) return BadRequest("Invalid request");
                var token = await _services.ValidateCredentials(tokenviewmodel);
                if (token == null) return BadRequest("Invalid request");
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("revoke")]
        public async Task<IActionResult> Revoke()
        {
            try
            {
                var username = User.Identity.Name;

                var result = await _services.RevokeToken(username);

                if(!result) return BadRequest("Invalid request");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[CustomAuthorize(PermissaoEnum.USUARIO_LISTAR)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var objs = await _services.GetAll();
                return Ok(objs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_LISTAR)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            try
            {
                var obj = await _services.FindByID(id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_CADASTRAR)]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Include([FromBody] Usuario obj)
        {
            try
            {
                obj = await _services.Create(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_EDITAR)]
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] Usuario obj, long id)
        {
            try
            {
                obj = await _services.Update(obj, id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_DELETAR)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _services.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
