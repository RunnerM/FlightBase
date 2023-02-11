namespace FlightBase;

public partial class AppShell : Shell
{
    public bool MapVisible { get; set; }
    
    public AppShell()
    {
        BindingContext = this;
        MapVisible = true;//DeviceInfo.Platform != DevicePlatform.WinUI;
        InitializeComponent();
        Title = "FlightBase";
    }
}