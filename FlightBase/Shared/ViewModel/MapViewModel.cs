using System.IO.Ports;
using System.Text.RegularExpressions;
using FlightBase.Shared.Domain.Model;
using FlightBase.Shared.Services.Common;
using Mapsui.UI.Maui;
using Mapsui.UI.Objects;
using MauiPosition = Mapsui.UI.Maui.Position;
using Position = FlightBase.Shared.Domain.Model.Position;


namespace FlightBase.Shared.ViewModel;

public class MapViewModel : BindableObject
{
    public IList<Drawable> Drawables { get; set; } = new List<Drawable>();
    private Track _track = new(new List<Position>());


    public MapViewModel(ISerialService serialService)
    {
        Drawables.Add(new Polyline()
        {
            StrokeColor = Color.FromRgb(255,0,0),
            StrokeWidth = 5,
        });
        serialService.AssignSerialHandler(HandleDataReceived);
    }

    private void HandleDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        var sp = (SerialPort)sender;
        var inData = sp.ReadLine();
        var position = Position.FromData(inData);
        if(position.Altitude==0 || position.Location.Latitude==0)
            return;
        _track.Add(position);
        var line = (Polyline) Drawables[0];
        line.Positions.Add(position.ToMapsMauiPosition());
    }
}