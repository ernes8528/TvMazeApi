using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace TvMazeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowsController : ControllerBase
    {
        private readonly ShowService _showService;
        public ShowsController(ShowService showService)
        {
            _showService = showService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Show>>> GetShows()
        {
            var shows = await _showService.GetShowsAsync();
            return Ok(shows);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShowByIdAsync(int id)
        {
            var show =  await _showService.GetShowByIdAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            return Ok(show);
        }
    }
}
