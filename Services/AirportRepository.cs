using Airport_distance_api.Interface;

namespace Airport_distance_api.Services
{
    public class AirportRepository : IAirportRepository
    {
        public Models.Coordinates GetAirportByCode(string code)
        {
            var Coordinates = GetCoordinates(code);
            return Coordinates;
        }

        public Models.Coordinates? GetCoordinates(string airportCode)
        {
            var airportCoordinates = new Dictionary<string, Models.Coordinates>
            {
                { "BOM", new Models.Coordinates { Latitude = 19.0974, Longitude = 72.8742 } },
                { "BLR", new Models.Coordinates { Latitude = 13.1993, Longitude = 77.7101 } },
                { "DEL", new Models.Coordinates { Latitude = 28.5561, Longitude = 77.1002 } },
                { "BBI", new Models.Coordinates { Latitude = 20.2563, Longitude = 85.8157 } },
                { "MAA", new Models.Coordinates { Latitude = 12.9811, Longitude = 80.1596 } },
                { "JAI", new Models.Coordinates { Latitude = 26.8289, Longitude = 75.8056 } },
                { "PNQ", new Models.Coordinates { Latitude = 18.5793, Longitude = 73.9089 } },
            };

            if (airportCoordinates.TryGetValue(airportCode.ToUpper(), out var coordinates))
            {
                return coordinates;
            }

            return null;
        }
    }
}
