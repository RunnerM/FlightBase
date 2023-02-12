using BruTile.Wms;

namespace FlightBase.Shared.Domain.Model;

public class Position
{
    public Location Location { get; set; }
    public double Altitude { get; set; }
    public double Speed { get; set; }

    public Position() { }

    public Position(Location location, double altitude, double speed)
    {
        Location = location;
        Altitude = altitude;
        Speed = speed;
    }

    public Position(double latitude, double longitude, double altitude, double speed)
    {
        Location = new Location(latitude, longitude);
        Altitude = altitude;
        Speed = speed;
    }

    /// <summary>
    /// Returns new instance of position from whole line of serial data.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static Position FromData(string line)
    {
        line= line.TrimEnd('\r');
        line=line.TrimEnd(';');
        var data = line.Split(',');
        return new Position(Location.FromData(data[0], data[1]), double.Parse(data[2]), double.Parse(data[3]));
    }

    public Mapsui.UI.Maui.Position ToMapsMauiPosition()
    {
        return new Mapsui.UI.Maui.Position((float) Location.Latitude, (float) Location.Longitude);
    }
}