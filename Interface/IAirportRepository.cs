using Airport_distance_api.Models;

namespace Airport_distance_api.Interface
{
    public interface IAirportRepository
    {
        Coordinates GetAirportByCode(string code);
    }
}
