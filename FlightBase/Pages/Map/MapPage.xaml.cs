using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBase.Shared.Domain.Model;
using FlightBase.Shared.ViewModel;
using Microsoft.Maui.Maps;
using Location = Microsoft.Maui.Devices.Sensors.Location;

namespace FlightBase;

public partial class MapPage : ContentPage
{

    public MapPage()
    {
        InitializeComponent();
        Location location = Geolocation.GetLastKnownLocationAsync().Result;
        if (location != null)
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(1)));
        BindingContext = new MapViewModel();
    }
}
