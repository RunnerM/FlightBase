using System.IO.Ports;
using FlightBase.Shared.Services.Common;
using Environment = System.Environment;

namespace FlightBase.Shared.ViewModel;

public class MainViewModel : BindableObject
{
    public string Altitude { get; set; }
    public string Location { get; set; }
    public string Speed { get; set; }
    public List<string> Logs { get; set; } = new();
    public string RenderedLog { get; set; }
    
    ISerialService _serialService;
    public MainViewModel(ISerialService serialService)
    {
        _serialService = serialService;
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            //_serialService.AssignSerialHandler(SerialDataReceivedAndroid);
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
        {
            _serialService.AssignSerialHandler(SerialDataReceivedWindows);
        }
    }

    private void SerialDataReceivedWindows(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadLine();
        Logs.Add(indata);
        RenderedLog += indata + Environment.NewLine;
        OnPropertyChanged(nameof(RenderedLog));
    }


    public void ClearLog()
    {
        Logs.Clear();
        RenderedLog = "";
        OnPropertyChanged(nameof(RenderedLog));
    }
}