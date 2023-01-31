namespace FlightBase;

public partial class AppShell : Shell
{
    public bool MapVisible { get; set; }
    
    public AppShell()
    {
        BindingContext = this;
        MapVisible = DeviceInfo.Platform != DevicePlatform.WinUI;
        InitializeComponent();
    }
}