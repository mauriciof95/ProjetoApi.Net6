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
        public async Task<IActionResult> Include([FromBody] DadosPedidoRequest obj)
        {
            try
            {
                await _services.RealizarPedido(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
