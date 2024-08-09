using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Services;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Core.Entities;

namespace TvMazeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly ShowService _showService;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public JobController(ShowService showService, IConfiguration configuration, HttpClient httpClient)
        {
            _showService = showService;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        [HttpPost("run")]
        public async Task<IActionResult> RunJob([FromQuery] string apiKey)
        {
            var configuredApiKey = _configuration["apiKey"];
            if(configuredApiKey != apiKey)
            {
                return Unauthorized();
            }

            var response = await _httpClient.GetStringAsync("http://api.tvmaze.com/shows");
            var shows = JsonConvert.DeserializeObject<List<Show>>(response);

            await _showService.StoreShowsAsync(shows);
            return Ok("Job executed successfully");
        }

    }
}
