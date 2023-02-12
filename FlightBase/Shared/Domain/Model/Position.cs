namespace FlightBase.Shared.Domain.Model;

public class Position
{
    private readonly Location _location = new Location();
    public double Altitude { get; set; }
    public double Speed { get; set; }
}