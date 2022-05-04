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
    public class PerfilController : ControllerBase
    {
        private PerfilServices _services;

        public PerfilController(ApiContext context) => _services = new PerfilServices(context);

        [CustomAuthorize(PermissaoEnum.PERFIL_LISTAR)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objs = await _services.GetAll();
            return Ok(objs);
        }

        [CustomAuthorize(PermissaoEnum.PERFIL_LISTAR)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var obj = await _services.FindByID(id);
            if (obj is null) return NotFound();
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.PERFIL_CADASTRAR)]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Include([FromBody] Perfil obj)
        {
            obj = await _services.Create(obj);
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.PERFIL_EDITAR)]
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] Perfil obj, long id)
        {
            obj = await _services.Update(obj, id);
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.PERFIL_DELETAR)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _services.Delete(id);
            return NoContent();
        }
    }
}
