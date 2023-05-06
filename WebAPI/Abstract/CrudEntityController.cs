using System;
using System.Threading.Tasks;
using Business.Utils;

using Core.Business.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Abstract
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudEntityController<TEntityGetDto, TEntityCreateDto, TEntityUpdateDto> : ControllerBase
        where TEntityGetDto : IEntityGetDto, new()
        where TEntityCreateDto : IDto, new()
        where TEntityUpdateDto : IDto, new()
    {
        private readonly ICrudEntityService<TEntityGetDto, TEntityCreateDto, TEntityUpdateDto> _service;

        public CrudEntityController(ICrudEntityService<TEntityGetDto, TEntityCreateDto, TEntityUpdateDto> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TEntityCreateDto input)
        {
            var result = await _service.AddAsync(input);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TEntityUpdateDto input)
        {
            var result = await _service.UpdateAsync(id, input);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}