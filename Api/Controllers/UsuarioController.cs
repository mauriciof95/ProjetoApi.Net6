using Api.Configuration;
using Api.Helpers;
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
    [CustomApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServices _services;
        public UsuarioController(UsuarioServices services, TokenConfiguration tokenConfig) => _services = services;

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthRequest auth)
        {
            if (auth == null) return BadRequest("Invalid request");
            var token = await _services.ValidateUser(auth);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenVM tokenviewmodel)
        {
            if (tokenviewmodel == null) return BadRequest("Invalid request");
            var token = await _services.ValidateCredentials(tokenviewmodel);
            if (token == null) return BadRequest("Invalid request");
            return Ok(token);
        }

        [HttpGet("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var username = User.Identity.Name;

            var result = await _services.RevokeToken(username);

            if (!result) return BadRequest("Invalid request");

            return NoContent();
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_LISTAR)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objs = await _services.GetAll();
            return Ok(objs);
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_LISTAR)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var obj = await _services.FindByID(id);
            if(obj is null) return NotFound();
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_CADASTRAR)]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Create([FromBody] UsuarioRequest obj)
        {
            await _services.Create(obj);
            return Ok();
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_EDITAR)]
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] Usuario obj, long id)
        {
            obj = await _services.Update(obj, id);
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.USUARIO_DELETAR)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _services.Delete(id);
            return NoContent();
        }

    }
}
