using System;
using System.Collections.Generic;
using System.Text;

namespace Ride.Application.Abstractions
{
    public interface IRideRepository
    {
        public record RequestRideCommand(Guid CustomerId, decimal PickupLatitude, decimal PickupLongitude, decimal DestinationLatitude, decimal DestinationLongitude);
    }
}
