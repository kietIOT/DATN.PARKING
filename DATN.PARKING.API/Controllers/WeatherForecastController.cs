using DATN.PARKING.DLL;
using Microsoft.AspNetCore.Mvc;

namespace DATN.PARKING.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IUnitOfWork<ParkingContext> _unitOfWork;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IUnitOfWork<ParkingContext> unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

      
    }
}
