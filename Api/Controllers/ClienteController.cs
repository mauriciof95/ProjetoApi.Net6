using Api.Helpers;
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
        private readonly ClienteServices _services;

        public ClienteController(ClienteServices service) => _services = service;

        [CustomAuthorize(PermissaoEnum.CLIENTE_LISTAR)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objs = await _services.GetAll();
            return Ok(objs);
        }

        [CustomAuthorize(PermissaoEnum.CLIENTE_LISTAR)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var obj = await _services.FindByID(id);
            if (obj is null) return NotFound();
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.CLIENTE_CADASTRAR)]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Include([FromBody] Cliente obj)
        {
            obj = await _services.Create(obj);
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.CLIENTE_EDITAR)]
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] Cliente obj, long id)
        {
            obj = await _services.Update(obj, id);
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.CLIENTE_DELETAR)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {

            await _services.Delete(id);
            return NoContent();
        }
    }
}
