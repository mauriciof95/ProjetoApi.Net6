using Api.Data.Context;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [Authorize("Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class MovimentacaoEstoqueController : ControllerBase
    {
        private MovimentacaoEstoqueServices _services;

        public MovimentacaoEstoqueController(ApiContext context) => _services = new MovimentacaoEstoqueServices(context);


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

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Include([FromBody] MovimentacaoEstoque obj)
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


        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] MovimentacaoEstoque obj, long id)
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
