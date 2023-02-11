using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBase.Shared.Domain.Model;
using FlightBase.Shared.ViewModel;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Nts;
using Mapsui.Nts.Extensions;
using Mapsui.Nts.Providers;
using Mapsui.Providers;
using Mapsui.Tiling;
using Mapsui.Widgets;
using Mapsui.Widgets.ScaleBar;
using Mapsui.Widgets.Zoom;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Maps;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using Color = Mapsui.Styles.Color;
using Easing = Mapsui.Utilities.Easing;
using Location = Microsoft.Maui.Devices.Sensors.Location;

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
        var map = MapControl.Map;
        map?.Layers.Add(OpenStreetMap.CreateTileLayer());
        var widget = new ZoomInOutWidget
        {
            BackColor = Color.Black,
            StrokeColor = Color.White,
            MarginY = 20,
            MarginX = 10
        };
        map?.Widgets.Add(widget);


        //BindingContext = mapViewModel;
    }
    
}
