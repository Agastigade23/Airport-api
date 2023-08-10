using Airport_distance_api.Interface;
using GeoCoordinatePortable;

namespace Airport_distance_api.Services
{
    public class DistanceRepository : IDistanceRepository
    {
        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // calculated distance in kilometers
            var fromGeoCoord = new GeoCoordinate(lat1, lon1);
            var toGeoCoord = new GeoCoordinate(lat2, lon2);

            return fromGeoCoord.GetDistanceTo(toGeoCoord) / 1000;
        }
    }
}
