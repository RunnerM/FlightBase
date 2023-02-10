
using FlightBase.Common.Domain;

namespace FlightBase.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var location = new Location();
        location.Latitude = 1;
        location.Longitude = 2;
        var position = new Position();
        position.Altitude = 3;
        position.Speed = 4;
        position.Location = location;
        Assert.Equal(1, position.Location.Latitude);
    }
    
}