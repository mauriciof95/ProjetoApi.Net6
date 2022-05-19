using Api.Helpers;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enum;

namespace Api.Controllers
{
    //[Authorize("Bearer")]
    [Route("[controller]")]
    [ApiController]

    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaServices _services;

        public CategoriaController(CategoriaServices services) => _services = services;

        //[CustomAuthorize(PermissaoEnum.CATEGORIA_LISTAR)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objs = await _services.GetAll();
            return Ok(objs);
        }

        [CustomAuthorize(PermissaoEnum.CATEGORIA_LISTAR)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var obj = await _services.FindByID(id);
            if (obj is null) return NotFound();
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.CATEGORIA_CADASTRAR)]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Include([FromBody] Categoria obj)
        {
            obj = await _services.Create(obj);
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.CATEGORIA_EDITAR)]
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] Categoria obj, long id)
        {
            obj = await _services.Update(obj, id);
            return Ok(obj);
        }

        [CustomAuthorize(PermissaoEnum.CATEGORIA_DELETAR)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _services.Delete(id);
            return NoContent();
        }
    }
}
