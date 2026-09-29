using Ride.Domain.Entities;
using Ride.Domain.Enums;
using Ride.Domain.ValueObjects;

namespace Ride.Domain.Tests;

public class RideTests
{
    [Fact]
    public void RequestingRide_ShouldSetStatusToRequested()
    {
        var pickup = new Location(28.6139, 77.2090);
        var destination = new Location(28.5355, 77.3910);

        var ride = Ride.Domain.Entities.Ride.Request(
            pickup,
            destination);

        Assert.Equal(
            RideStatus.Requested,
            ride.Status);
    }
    [Fact]
    public void StartSearching_ShouldChangeStatusToSearching()
    {
        var ride = CreateRide();

        ride.StartSearching();

        Assert.Equal(
            RideStatus.Searching,
            ride.Status);
    }
    [Fact]
    public void AssignDriver_ShouldChangeStatusToDriverAssigned()
    {
        var ride = CreateRide();

        ride.StartSearching();

        var driverId = Guid.NewGuid();

        ride.AssignDriver(driverId);

        Assert.Equal(
            RideStatus.DriverAssigned,
            ride.Status);

        Assert.Equal(
            driverId,
            ride.DriverId);
    }

    [Fact]
    public void CompletedRide_ShouldNotAllowDriverAssignment()
    {
        var ride = CreateRide();

        ride.StartSearching();
        ride.AssignDriver(Guid.NewGuid());
        ride.StartRide();
        ride.CompleteRide();

        Assert.Throws<InvalidOperationException>(
            () => ride.AssignDriver(Guid.NewGuid()));
    }

    private static Ride.Domain.Entities.Ride CreateRide()
    {
        return Ride.Domain.Entities.Ride.Request(
            new Location(28.6139, 77.2090),
            new Location(28.5355, 77.3910));
    }
}
