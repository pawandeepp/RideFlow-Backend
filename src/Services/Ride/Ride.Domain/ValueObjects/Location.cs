using System;
using System.Collections.Generic;
using System.Text;

namespace Ride.Domain.ValueObjects
{
    // sealed class cannot inherited as base class ->
    // 1) use it for pridicabloe behaviour if no one inherit it noone can override it as well , 
    //2) fix value object
    //normal: can be instantiated and inherited
    //sealed: can be instantiated, cannot be inherited
    //abstract: cannot be instantiated, must be inherited
    public sealed class Location
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public Location(double latitude, double longitude)
        {
            if (latitude is < -90 or > 90)
                throw new ArgumentException("Invalid latitude.");

            if (longitude is < -180 or > 180)
                throw new ArgumentException("Invalid longitude.");

            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
