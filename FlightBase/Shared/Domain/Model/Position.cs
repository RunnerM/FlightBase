using BruTile.Wms;
using System.Text.RegularExpressions;

namespace FlightBase.Shared.Domain.Model;

public class Position
{
    public Location Location { get; set; }
    public double Altitude { get; set; }
    public double Speed { get; set; }

    private static readonly Regex Regex = new("[A-Za-z]\\d\\d\\d\\d\\.\\d\\d\\d\\d\\d,[A-Za-z]\\d\\d\\d\\d\\d\\.\\d\\d\\d\\d\\d,\\d\\d\\d\\d\\d\\d,[0-9]*\\.[0-9]+;", RegexOptions.IgnoreCase);


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
        if (!Regex.IsMatch(line))  return new Position();
        line = line.TrimEnd('\r');
        line=line.TrimEnd(';');
        var data = line.Split(',');
        return new Position(Location.FromData(data[0], data[1]), double.Parse(data[2]), double.Parse(data[3]));
    }

    public Mapsui.UI.Maui.Position ToMapsMauiPosition()
    {
        return new Mapsui.UI.Maui.Position((float) Location.Latitude, (float) Location.Longitude);
    }
}