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

        public double CalculateDistancewithout(double lat1, double lon1, double lat2, double lon2)
        {
            // calculated distance in kilometers
            const double EarthRadius = 6371; // Radius of Earth in kilometers

            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = EarthRadius * c;
            return distance;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

    }
}
