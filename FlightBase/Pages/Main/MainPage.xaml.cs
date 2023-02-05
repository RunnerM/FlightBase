namespace FlightBase;

public partial class MainPage : ContentPage
{
    
    public MainPage()
    {
        InitializeComponent();
        AltitudeLabel.Text = "0";
        LocationLabel.Text = "0";
        SpeedLabel.Text = "0";
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            LogRowDefinition.Height = new GridLength(350);
        else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            LogRowDefinition.Height = new GridLength(500);
    }

    private void Button_OnPressed(object sender, EventArgs e)
    {
        SerialLogLabel.Text += "Logs .... " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine;
    }
}