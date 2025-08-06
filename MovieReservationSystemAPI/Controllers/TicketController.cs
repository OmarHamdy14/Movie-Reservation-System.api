using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs;
using MovieReservationSystemAPI.Models;
using Stripe;
using Stripe.BillingPortal;

namespace MovieReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IConfiguration _configuration;
        private readonly IHubContext<Hub> _hubContext;
        public TicketController(ITicketService ticketService, IConfiguration configuration, IHubContext<Hub> hubContext)
        {
            _ticketService = ticketService;
            _configuration = configuration;
            _hubContext = hubContext;
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
        /*[HttpGet("GetAllByTheaterId/{TheaterId}")]
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
        }*/
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
        [HttpPost]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeSecret = _configuration["Stripe:WebhookSecret"];

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], stripeSecret);

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var ticketId = int.Parse(HttpContext.Request.Query["ticketId"]);

                    var ticket = await _ticketService.GetById(ticketId);

                    if (ticket != null && !ticket.IsBooked)
                    {
                        ticket.IsBooked = true;
                        ticket.Lock = null;
                        await _ticketService.Update(ticket);

                        await _hubContext.Clients.Group($"MovieSchedule-{ticket.MovieScheduleId}")
                            .SendAsync("TicketBooked", new { TicketId = ticket.Id });
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        
        
        /*
        [HttpPut("LockTicket/{TicketId}")]
        public async Task<IActionResult> LockTicket(Guid TicketId)
        {
            try
            {
                var ticket = await _ticketService.GetById(TicketId);
                if (ticket == null) return NotFound();
                var res = await _ticketService.LockTicket(ticket);
                if (!res) return BadRequest(new { Message = "Ticket is locked or booked by someone" });
                return Ok(new { Message = "Ticket is locked" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
            if (ticket.IsBooked || ticket.Lock > DateTime.UtcNow) return false;
            ticket.Lock = DateTime.UtcNow.AddMinutes(5);
            await _base.Update(ticket);
            return true;
        }
        [HttpPut("BookTicket")]
        public async Task<bool> BookTicket(Ticket ticket)
        {
            if (ticket.IsBooked || ticket.Lock < DateTime.UtcNow) return false;
            ticket.IsBooked = true;
            ticket.Lock = null;
            await _base.Update(ticket);

            await _hubContext.Clients.Groups($"MovieSchedule:{ticket.MovieScheduleId}").SendAsync("BookedSeat", new { TicketId = ticket.Id });
            return true;
        }
        */

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