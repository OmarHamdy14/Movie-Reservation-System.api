using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieReservationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id) // use include 
        {
            try
            {
                var movie = await _movieService.GetById(Id);
                if(movie == null) return NotFound();
                return Ok(movie);
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
                return Ok(await _movieService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CreateMovieDTO model, [FromForm]IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var movie = await _movieService.Create(model,file);
                    return Ok(movie);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Something went wrong." });
            }
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] UpdateMovieDTO model, [FromForm] IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var movie = await _movieService.GetById(Id);
                    if (movie == null) return NotFound();
                    var res = await _movieService.Update(movie, model, file);
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
                    var movie = await _movieService.GetById(Id);
                    if (movie == null) return NotFound();
                    await _movieService.Delete(movie);
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
