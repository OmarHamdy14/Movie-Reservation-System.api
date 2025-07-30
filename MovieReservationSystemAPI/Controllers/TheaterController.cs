using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationSystemAPI.Helpers.DTOs.TheaterDTOs;

namespace MovieReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ITheaterService _theaterService;
        public TheaterController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var theater = await _theaterService.GetById(Id);
                if (theater == null) return NotFound();
                return Ok(theater);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _theaterService.GetAll();
                if (!res.Any()) return NotFound();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTheaterDTO model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var res = await _theaterService.Create(model);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] UpdateTheaterDTO model)
        {
            try
            {
                var theater = await _theaterService.GetById(Id);
                if (theater == null) return NotFound();
                var res = await _theaterService.Update(theater, model);
                return Ok(theater);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id){
            try
            {
                var theater = await _theaterService.GetById(Id);
                if (theater == null) return NotFound();
                await _theaterService.Delete(theater);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
    }
}
