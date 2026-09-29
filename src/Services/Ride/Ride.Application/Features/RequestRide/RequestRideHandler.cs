using Ride.Application.Abstractions;
using Ride.Domain.Entities;
using Ride.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ride.Application.Features.RequestRide
{
    public class RequestRideHandler
    {
        public Guid Handle(RequestRideCommand command)
        {
            var pickup = new Location(
            command.PickupLatitude,
            command.PickupLongitude);

            var destination = new Location(
                command.DestinationLatitude,
                command.DestinationLongitude);

            var ride = Ride.Domain.Entities.Ride.Request(
                pickup,
                destination);

            // Persistence will come later.

            return ride.Id;
        }
    }
}
