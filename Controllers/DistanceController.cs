using Airport_distance_api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport_distance_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IDistanceRepository _distanceRepository;

        public DistanceController(IAirportRepository airportRepository, IDistanceRepository distanceRepository)
        {
            _airportRepository = airportRepository;
            _distanceRepository = distanceRepository;
        }

        [HttpGet("{source}/{destination}")]
        public IActionResult GetDistanceWithout(string source, string destination)
        {
            var sourceAirport = _airportRepository.GetAirportByCode(source);
            var destinationAirport = _airportRepository.GetAirportByCode(destination);

            if (sourceAirport == null || destinationAirport == null)
            {
                return NotFound("One or both airports not found.");
            }

            double distance = _distanceRepository.CalculateDistancewithout(
                sourceAirport.Latitude, sourceAirport.Longitude,
                destinationAirport.Latitude, destinationAirport.Longitude);

            return Ok(new { DistanceInKilometers = distance });
        }
    }
}
