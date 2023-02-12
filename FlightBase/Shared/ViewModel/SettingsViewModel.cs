using FlightBase.Shared.Services;
using FlightBase.Shared.Services.Common;

namespace FlightBase.Shared.ViewModel;

public class SettingsViewModel : BindableObject
{
    private readonly ISerialService _serialService;
    public List<string> Ports { get; set; }
    public List<int> Bauds { get; set; }

    public string ConnectBtnText { get; set; } = "Connect";
    
    public bool IsConnected => _serialService.IsConnected();
    
    public SettingsViewModel(ISerialService serialService)
    {
        _serialService = serialService;
        ScanPorts();
        Bauds = new List<int>() {9600, 19200, 38400, 57600, 115200};
    }
    
    public void ScanPorts()
    {
        Ports = _serialService.ScanPortsAsync().GetAwaiter().GetResult();
        OnPropertyChanged(nameof(Ports));
    }
    
    public void SetBaudRate(int baudRate)
    {
        _serialService.ConfigureBaudRate(baudRate);
    }
    public void ConfigurePort(string portName)
    {
        _serialService.ConfigurePort(portName);
    }
    
    public Task<bool> Connect()
    {
        if (_serialService.Connect().Result)
        {
            ConnectBtnText = "Disconnect";
            OnPropertyChanged(nameof(ConnectBtnText));
        }
        return Task.FromResult(false);
    }
    
    public Task<bool> Disconnect()
    {
        if (_serialService.Disconnect().Result)
        {
            ConnectBtnText = "Connect";
            OnPropertyChanged(nameof(ConnectBtnText));
        }
        return Task.FromResult(false);
    }
}