using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationSystemAPI.Helpers.DTOs.SeatDTOs;

namespace MovieReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;
        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var seat = await _seatService.GetById(Id);
                if (seat == null) return NotFound();
                return Ok(seat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpGet("GetAllTheaterId/{TheaterId}")]
        public async Task<IActionResult> GetAllTheaterId(Guid TheaterId)
        {
            try
            {
                var seats = await _seatService.GetAllByTheaterId(TheaterId);
                if(!seats.Any()) return NotFound();
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSeatDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _seatService.Create(model);
                    return Ok(res);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] UpdateSeatDTO model)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var seat = await _seatService.GetById(Id);
                if(seat == null) return NotFound();
                await _seatService.Update(seat, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var seat = await _seatService.GetById(Id);
                if (seat == null) return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
    }
}
