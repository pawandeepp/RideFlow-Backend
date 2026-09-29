using System;
using System.Collections.Generic;
using System.Text;

namespace Ride.Domain.Enums
{
    public enum RideStatus
    {
        Requested,
        Searching,
        DriverAssigned,
        InProgress,
        Completed,
        Cancelled
    }
}
