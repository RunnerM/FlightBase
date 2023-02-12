using FlightBase.Shared.Domain.Model;
using Mapsui.UI.Maui;
using Mapsui.UI.Objects;
using Position = Mapsui.UI.Maui.Position;

namespace FlightBase.Shared.ViewModel;

public class MapViewModel : BindableObject
{
    public IList<Drawable> Drawables { get; set; } = new List<Drawable>();
    public IList<Pin> Pins { get; set; } = new List<Pin>();

    public Pin Selected { get; set; }

    public MapViewModel()
    {
        Drawables.Add(new Polyline()
        {
            Positions =
            {
                new Position(55.8581, 9.8476),
                new Position(55.8571, 9.8466),
                new Position(55.8561, 9.8456),
            },
            StrokeColor = Colors.Red,
            StrokeWidth = 5
        });

        Pins.Add(new Pin()
        {
            Label = "Test",
            Position = new Position(55.8581, 9.8476)
        });
        Thread thread = new Thread(AddMorePins);
        thread.Start();
    }

    public void AddMorePins()
    {
        var k = (Polyline) Drawables[0];
        var newlat = k.Positions.Last().Latitude - 0.0001;
        var newlon = k.Positions.Last().Longitude - 0.0001;
        k.Positions.Add(new Position(newlat, newlon));
        Drawables.Add(new Circle()
        {
            Center = new Position(newlat, newlon),
            Radius = new Distance(20),
            FillColor= Colors.Red,
        });
        Thread.Sleep(1000);
        AddMorePins();
    }
}