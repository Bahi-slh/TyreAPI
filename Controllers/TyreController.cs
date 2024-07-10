using Microsoft.AspNetCore.Mvc;
using TyreManagementAPI.Models.DTOs;
using TyreManagementAPI.Models.Entities;
using TyreManagementAPI.Services.Interfaces;

namespace TyreManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TyresController : ControllerBase
    {
        private readonly ITyreService _tyreService;

        public TyresController(ITyreService tyreService)
        {
            _tyreService = tyreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tyre>>> GetTyres()
        {
            var tyres = await _tyreService.GetAllTyresAsync();
            return Ok(tyres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tyre>> GetTyre(int id)
        {
            var tyre = await _tyreService.GetTyreByIdAsync(id);
            if (tyre == null)
            {
                return NotFound();
            }
            return Ok(tyre);
        }

        [HttpPost]
        public async Task<ActionResult<Tyre>> PostTyre(CreateTyreDto tyreDto)
        {
            var createdTyre = await _tyreService.CreateTyreAsync(tyreDto);
            return CreatedAtAction(nameof(GetTyre), new { id = createdTyre.Id }, createdTyre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTyre(int id, UpdateTyreDto tyreDto)
        {
            await _tyreService.UpdateTyreAsync(id, tyreDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTyre(int id)
        {
            await _tyreService.DeleteTyreAsync(id);
            return NoContent();
        }
    }
}