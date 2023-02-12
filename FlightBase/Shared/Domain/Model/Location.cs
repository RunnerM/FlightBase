namespace FlightBase.Shared.Domain.Model;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Location() { }

    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    /// <summary>
    /// Returns new instance of position from formatted string as X0000.00000
    /// </summary>
    /// <param name="latitude"></param>
    /// <param name="longitude"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static Location FromData(string latitude, string longitude)
    {
        var lat = latitude[0] switch
        {
            'N' => double.Parse(latitude[1..]),
            'S' => double.Parse(latitude[1..]) * (-1),
            _ => throw new ArgumentException()
        };
        var lng = longitude[0] switch
        {
            'E' => double.Parse(longitude[1..]),
            'W' => double.Parse(longitude[1..]) * (-1),
            _ => throw new ArgumentException()
        };

        return new Location(lat/100,lng/100);
    }

}


