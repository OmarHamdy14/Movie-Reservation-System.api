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
                if(theater == null) return NotFound();
                return Ok(theater);
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
    }
}
