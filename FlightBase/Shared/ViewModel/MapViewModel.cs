using System.IO.Ports;
using System.Text.RegularExpressions;
using FlightBase.Shared.Domain.Model;
using FlightBase.Shared.Services.Common;
using Mapsui.UI.Maui;
using Mapsui.UI.Objects;
using static Android.Renderscripts.ScriptGroup;
using MauiPosition = Mapsui.UI.Maui.Position;
using Position = FlightBase.Shared.Domain.Model.Position;


namespace FlightBase.Shared.ViewModel;

public class MapViewModel : BindableObject
{
    public IList<Drawable> Drawables { get; set; } = new List<Drawable>();
    private Track _track = new(new List<Position>());
    private static readonly Regex Regex = new("[A-Za-z]\\d\\d\\d\\d\\.\\d\\d\\d\\d\\d,[A-Za-z]\\d\\d\\d\\d\\d\\.\\d\\d\\d\\d\\d,\\d\\d\\d\\d\\d\\d,[0-9]*\\.[0-9]+;",RegexOptions.IgnoreCase);


    public MapViewModel(ISerialService serialService)
    {
        Drawables.Add(new Polyline());
        serialService.AssignSerialHandler(HandleDataReceived);
    }

    private void HandleDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        var sp = (SerialPort)sender;
        var inData = sp.ReadLine();
        if (!Regex.IsMatch(inData)) return;
        var position = Position.FromData(inData);
        _track.Add(position);
        var line = (Polyline) Drawables[0];
        line.Positions.Add(position.ToMapsMauiPosition());
    }
}