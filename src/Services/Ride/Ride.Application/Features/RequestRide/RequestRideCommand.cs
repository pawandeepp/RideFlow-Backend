using System;
using System.Collections.Generic;
using System.Text;

namespace Ride.Application.Features.RequestRide
{
    public record RequestRideCommand(
    double PickupLatitude,
    double PickupLongitude,
    double DestinationLatitude,
    double DestinationLongitude);
}
