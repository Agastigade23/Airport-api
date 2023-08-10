namespace Airport_distance_api.Interface
{
    public interface IDistanceRepository
    {
        double CalculateDistance(double lat1, double lon1, double lat2, double lon2);

        double CalculateDistancewithout(double lat1, double lon1, double lat2, double lon2);
    }
}
