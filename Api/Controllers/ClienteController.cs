using Api.Helpers;
using Api.Data.Context;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enum;

namespace Api.Controllers
{
    [Authorize("Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteServices _services;

        public ClienteController(ApiContext context) => _services = new ClienteServices(context);

        [CustomAuthorize(PermissaoEnum.CLIENTE_LISTAR)]
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

        [CustomAuthorize(PermissaoEnum.CLIENTE_LISTAR)]
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

        [CustomAuthorize(PermissaoEnum.CLIENTE_CADASTRAR)]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Include([FromBody] Cliente obj)
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

        [CustomAuthorize(PermissaoEnum.CLIENTE_EDITAR)]
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] Cliente obj, long id)
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

        [CustomAuthorize(PermissaoEnum.CLIENTE_DELETAR)]
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
