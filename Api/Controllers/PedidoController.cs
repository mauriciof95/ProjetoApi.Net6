using Api.Data.Context;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private PedidoServices _services;

        public PedidoController(ApiContext context) => _services = new PedidoServices(context);

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
        public async Task<IActionResult> Include([FromBody] DadosPedidoRequest obj)
        {
            await _services.RealizarPedido(obj);
            return Ok();
        }
    }
}
