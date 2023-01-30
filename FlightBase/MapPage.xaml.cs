using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Maps;

namespace FlightBase;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
        Map.MapType = MapType.Satellite;
        Location location = Geolocation.GetLastKnownLocationAsync().Result;
        if(location != null)
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(1)));
    }
}