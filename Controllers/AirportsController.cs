using Airport_distance_api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport_distance_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IDistanceRepository _distanceRepository;

        public AirportsController(IAirportRepository airportRepository, IDistanceRepository distanceRepository)
        {
            _airportRepository = airportRepository;
            _distanceRepository = distanceRepository;
        }

        [HttpGet("{sourceCode}/{destinationCode}")]
        public IActionResult GetDistance(string sourceCode, string destinationCode)
        {
            var sourceAirport = _airportRepository.GetAirportByCode(sourceCode);
            var destinationAirport = _airportRepository.GetAirportByCode(destinationCode);

            if (sourceAirport == null || destinationAirport == null)
            {
                return NotFound("One or both airports not found.");
            }

            double distance = _distanceRepository.CalculateDistance(
                sourceAirport.Latitude, sourceAirport.Longitude,
                destinationAirport.Latitude, destinationAirport.Longitude);

            return Ok(new { DistanceInKilometers = distance });
        }
    }
}
