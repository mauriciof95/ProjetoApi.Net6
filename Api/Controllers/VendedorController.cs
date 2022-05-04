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
    public class VendedorController : ControllerBase
    {
        private VendedorServices _services;

        public VendedorController(ApiContext context) => _services = new VendedorServices(context);


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objs = await _services.GetAll();
            return Ok(objs);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var obj = await _services.FindByID(id);
            if (obj is null) return NotFound();
            return Ok(obj);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Include([FromBody] Vendedor obj)
        {
            obj = await _services.Create(obj);
            return Ok(obj);
        }


        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] Vendedor obj, long id)
        {
            obj = await _services.Update(obj, id);
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _services.Delete(id);
            return NoContent();
        }
    }
}
