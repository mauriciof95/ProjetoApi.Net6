﻿using Api.Services;
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
        private readonly MovimentacaoEstoqueServices _services;

        public MovimentacaoEstoqueController(MovimentacaoEstoqueServices services) => _services = services;


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
        public async Task<IActionResult> Include([FromBody] StockMoviment obj)
        {
            obj = await _services.Create(obj);
            return Ok(obj);
        }


        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update([FromBody] StockMoviment obj, long id)
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
