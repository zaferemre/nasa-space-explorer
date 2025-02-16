using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NasaExplorer.Services;

namespace NasaExplorer.Controllers
{
    [ApiController]
    [Route("api/nasa")] // ✅ Defines API route
    public class NasaController : ControllerBase
    {
        private readonly NasaService _nasaService;
        private readonly string _apiKey;
        public NasaController(NasaService nasaService)
        {
            _nasaService = nasaService;
            _apiKey = System.Environment.GetEnvironmentVariable("NASA_API_KEY");
        }

        [HttpGet("apod")]
        public async Task<IActionResult> GetApodAsync()
        {
            
            var data = await _nasaService.GetApodAsync(_apiKey);
            return Ok(new { imageUrl = data });
        }

        [HttpGet("mars-rover-photos")]
        public async Task<IActionResult> GetMarsRoverPhotos(string rover = "curiosity", string earthDate = "2024-02-16")
        {
            var data = await _nasaService.GetMarsRoverPhotos(rover, earthDate, _apiKey);
            return Ok(new { photos = data });
        }
        [HttpGet("asteroids")]
        public async Task<IActionResult> GetAsteroids()
        {
            var data = await _nasaService.GetAsteroids(_apiKey);
            return Ok(new { asteroids = data });
        }

        [HttpGet("iss")]
        public async Task<IActionResult> GetIssLocation()
        {
            var data = await _nasaService.GetIssLocationAsync();
            return Ok(new { iss_position = data });
        }
    }
}
