using Microsoft.AspNetCore.Mvc;
using Ride.Api.Models;
using Ride.Application.Features.RequestRide;
namespace Ride.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RideController : ControllerBase
{
    private readonly RequestRideHandler _handler;
    public RideController(RequestRideHandler handler)
    {
        _handler = handler;
    }
    [HttpPost]
    [Route("RequestRide")]
    public IActionResult RequestRide(RequestRideRequest request)
    {
        var command = new RequestRideCommand(
            request.Pickup.Latitude,
            request.Pickup.Longitude,
            request.Destination.Latitude,
            request.Destination.Longitude);
        var rideId = _handler.Handle(command);

        return Ok(new RideResponse(
            rideId,
            "Requested"));
    }
}

