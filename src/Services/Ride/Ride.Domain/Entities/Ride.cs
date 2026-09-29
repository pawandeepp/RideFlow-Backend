using Ride.Domain.Enums;
using Ride.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ride.Domain.Entities
{
    public class Ride
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public Location Pickup { get; private set; } = null!;


        public Location Destination { get; private set; } = null!;

        public RideStatus Status { get; private set; }

        public Guid? DriverId { get; private set; }

        private Ride()
        {
            //EF core Later
        }
        public Ride(Guid customerId,Location pickup, Location destination)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;

            Pickup = pickup;
            Destination = destination;

            Status = RideStatus.Requested;
        }
        public static Ride Request(
        Location pickup,
        Location destination)
        {
            return new Ride(
                Guid.NewGuid(),
                pickup,
                destination);
        }
        public void StartSearching()
        {
            if (Status != RideStatus.Requested)
                throw new InvalidOperationException(
                    "Ride cannot start searching from its current state.");

            Status = RideStatus.Searching;
        }
        public void AssignDriver(Guid driverId)
        {
            if (Status != RideStatus.Searching)
                throw new InvalidOperationException(
                    $"Cannot assign driver when ride is {Status}.");

            if (driverId == Guid.Empty)
                throw new ArgumentException("Driver ID cannot be empty.");

            DriverId = driverId;
            Status = RideStatus.DriverAssigned;
        }
        public void StartRide()
        {
            if (Status != RideStatus.DriverAssigned)
                throw new InvalidOperationException(
                    $"Cannot start ride when ride is {Status}.");

            Status = RideStatus.InProgress;
        }
        public void CompleteRide()
        {
            if (Status != RideStatus.InProgress)
                throw new InvalidOperationException(
                    $"Cannot complete ride when ride is {Status}.");

            Status = RideStatus.Completed;
        }
        //not expecting setter everywhere
        //The domain controls its own state transitions.

        //Requested
        //    ↓
        //Searching
        //    ↓
        //DriverAssigned
    }
}
