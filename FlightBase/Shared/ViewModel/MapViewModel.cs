using System.ComponentModel;
using FlightBase.Shared.Domain.Model;
using Microsoft.Maui.Maps;

namespace FlightBase.Shared.ViewModel;

public class MapViewModel
{
    public List<mapType> MapTypes { get; set; }
    public mapType SelectedMapType { get; set; }
    public string _mapStyle { get; set; }
    
    public MapViewModel()
    {
        _mapStyle = "";
        MapTypes = new List<mapType>
        {
            new mapType {Name = "Satellite", Type = MapType.Satellite},
            new mapType {Name = "Street", Type = MapType.Street},
            new mapType {Name = "Hybrid", Type = MapType.Hybrid},
        };
    }
}