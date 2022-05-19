using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize("Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class PerfilPermissoesController : ControllerBase
    {
        /*private PerfilPermissoesServices _services;

        public PerfilPermissoesController(ApiContext context) => _services = new PerfilPermissoesServices(context);

        [CustomAuthorize(PermissaoEnum.PERFIL_PERMISSAO_LISTAR)]
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

        [CustomAuthorize(PermissaoEnum.PERFIL_PERMISSAO_LISTAR)]
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

        [CustomAuthorize(PermissaoEnum.PERFIL_PERMISSAO_CADASTRAR)]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Include([FromBody] PerfilPermissao obj)
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

        [CustomAuthorize(PermissaoEnum.PERFIL_PERMISSAO_EDITAR)]
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] PerfilPermissao obj, long id)
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

        [CustomAuthorize(PermissaoEnum.PERFIL_PERMISSAO_DELETAR)]
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
        }*/
    }
}
