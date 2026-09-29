namespace Ride.Api.Models
{
    public class RequestRideRequest
    {
        public LocationRequest Pickup { get; set; } = null!;

        public LocationRequest Destination { get; set; } = null!;
    }

    public class LocationRequest
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
