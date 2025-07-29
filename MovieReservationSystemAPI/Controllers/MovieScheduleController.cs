using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;

namespace MovieReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieScheduleController : ControllerBase
    {
        private readonly IMovieScheduleService _movieScheduleService;
        public MovieScheduleController(IMovieScheduleService movieScheduleService)
        {
            _movieScheduleService = movieScheduleService;
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            try
            {
                var movieSchedule = await _movieScheduleService.GetById(Id);
                if (movieSchedule == null) return NotFound();
                return Ok(movieSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpGet("GetAllByMovieId/{MovieId}")]
        public async Task<IActionResult> GetAllByMovieId(Guid MovieId)
        {
            try
            {
                return Ok(await _movieScheduleService.GetAllByMovieId(MovieId));
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
                return Ok(await _movieScheduleService.GetAllByMovieId(TheaterId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateMovieScheduleDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var movieSchedule = await _movieScheduleService.Create(model);
                    return Ok(movieSchedule);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] UpdateMovieScheduleDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var movieSchedule = await _movieScheduleService.GetById(Id);
                    if (movieSchedule == null) return NotFound();
                    var res = await _movieScheduleService.Update(movieSchedule, model);
                    return Ok(res);
                }
                return BadRequest(ModelState);
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
                if (ModelState.IsValid)
                {
                    var movieSchedule = await _movieScheduleService.GetById(Id);
                    if (movieSchedule == null) return NotFound();
                    await _movieScheduleService.Delete(movieSchedule);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
    }
}
