using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs;
using MovieReservationSystemAPI.Models;

namespace MovieReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var ticket = await _ticketService.GetById(Id);
                if (ticket == null) return NotFound();
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpGet("GetAllByUserId/{UserId}")]
        public async Task<IActionResult> GetAllByUserId(string UserId)
        {
            try
            {
                var tickets = await _ticketService.GetAllByUserId(UserId);
                if (!tickets.Any()) return NotFound();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpGet("GetAllByTheaterId/{TheaterId}")]
        public async Task<IActionResult> GetAllByTheaterId(Guid TheaterId)
        {
            try
            {
                var tickets = await _ticketService.GetAllByTheaterId(TheaterId);
                if (!tickets.Any()) return NotFound();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpGet("GetAllByMovieScheduleIdId/{MovieScheduleIdId}")]
        public async Task<IActionResult> GetAllByMovieScheduleIdId(Guid MovieScheduleIdId)
        {
            try
            {
                var tickets = await _ticketService.GetAllByMovieScheduleIdId(MovieScheduleIdId);
                if (!tickets.Any()) return NotFound();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpGet("GetAllBySeatId/{SeatId}")]
        public async Task<IActionResult> GetAllBySeatId(Guid SeatId)
        {
            try
            {
                var tickets = await _ticketService.GetAllBySeatId(SeatId);
                if (!tickets.Any()) return NotFound();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTicketDTO model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var res = await _ticketService.Create(model);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] UpdateTicketDTO model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var ticket = await _ticketService.GetById(Id);
                if (ticket == null) return NotFound();
                var res = await _ticketService.Update(ticket,model);
                return Ok(res);
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
                var ticket = await _ticketService.GetById(Id);
                if (ticket == null) return NotFound();
                await _ticketService.Delete(ticket);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
    }
}