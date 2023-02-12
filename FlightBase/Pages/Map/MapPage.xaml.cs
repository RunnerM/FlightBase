using FlightBase.Shared.ViewModel;
using Mapsui.Extensions;
using Mapsui.Tiling;
using Mapsui.Widgets.Zoom;
using NetTopologySuite.Geometries;
using Color = Mapsui.Styles.Color;
using Position = Mapsui.UI.Maui.Position;


namespace FlightBase;

public partial class MapPage : ContentPage
{
    public MapPage(MapViewModel mapViewModel)
    {
        InitializeComponent();
        //Location location;
        //location = Geolocation.GetLastKnownLocationAsync().Result;

        //if (location != null)
        // Map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(1)));
        //var mapControl = new Mapsui.UI.Maui.MapControl();
        MapView.Map?.Layers.Add(OpenStreetMap.CreateTileLayer());
        MapView.Pins.Add(new Mapsui.UI.Maui.Pin()
        {
            Label = "Test",
            Position = new Position(55.8581, 9.8476)
        });
        MapView.Drawables.Add(new Mapsui.UI.Maui.Polyline()
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


        //BindingContext = mapViewModel;
    }
}