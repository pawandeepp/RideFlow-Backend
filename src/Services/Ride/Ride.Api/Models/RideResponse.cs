namespace Ride.Api.Models
{
    //record is shortcut for defining a small immutable data carrying type.
    public record RideResponse(
    Guid RideId,
    string Status);
}
