using System.ComponentModel;
using System.Runtime.CompilerServices;
using FlightBase.Shared.Domain.Model;
using Microsoft.Maui.Maps;
using MapType = FlightBase.Shared.Domain.Model.MapType;

namespace FlightBase.Shared.ViewModel;

public class MapViewModel
{
    public List<MapType> MapTypes { get; set; }
    public MapType SelectedMapType { get; set; }
    public MapViewModel()
    {
        SelectedMapType = new MapType {Name = "Satellite", Type = Microsoft.Maui.Maps.MapType.Satellite};
        MapTypes = new List<MapType>
        {
            new MapType {Name = "Satellite", Type = Microsoft.Maui.Maps.MapType.Satellite},
            new MapType {Name = "Street", Type = Microsoft.Maui.Maps.MapType.Street},
            new MapType {Name = "Hybrid", Type = Microsoft.Maui.Maps.MapType.Hybrid},
        };
    }
}