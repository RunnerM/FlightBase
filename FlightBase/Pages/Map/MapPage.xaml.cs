using FlightBase.Shared.ViewModel;
using Mapsui.Extensions;
using Mapsui.Tiling;
using Mapsui.UI.Objects;
using Mapsui.Widgets.Zoom;
using Microsoft.Maui.Controls.Shapes;
using NetTopologySuite.Geometries;
using Color = Mapsui.Styles.Color;
using Position = Mapsui.UI.Maui.Position;


namespace FlightBase;

public partial class MapPage : ContentPage
{
    private readonly BindableProperty DrawablesProperty = BindableProperty.Create(
        nameof(Drawables),
        typeof(IList<Drawable>),
        typeof(MapPage), null, BindingMode.OneWay,
        propertyChanged: OnDrawableChanged);

    private static void OnDrawableChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is MapPage mapPage)
        {
            mapPage.MapView.Drawables.Clear();
            foreach (var drawable in (IList<Drawable>) newvalue)
            {
                mapPage.MapView.Drawables.Add(drawable);
            }
        }
    }

    private IList<Drawable> Drawables
    {
        get => (IList<Drawable>) GetValue(DrawablesProperty);
        set => SetValue(DrawablesProperty, value);
    }
    
    public MapPage(MapViewModel mapViewModel)
    {
        InitializeComponent();
        MapView.Map?.Layers.Add(OpenStreetMap.CreateTileLayer());
        MapView.MyLocationEnabled = true;
        MapView.MyLocationFollow = true;
        BindingContext= mapViewModel;
        Drawables = mapViewModel.Drawables;
    }
}