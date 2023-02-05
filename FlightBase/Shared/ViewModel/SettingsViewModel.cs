using FlightBase.Shared.Services;
using FlightBase.Shared.Services.Common;

namespace FlightBase.Shared.ViewModel;

public class SettingsViewModel : BindableObject
{
    private readonly ISerialService _serialService;
    public List<string> Ports { get; set; }
    public List<int> Bauds { get; set; }
    
    public SettingsViewModel(ISerialService serialService)
    {
        _serialService = serialService;
        ScanPorts();
        Bauds = new List<int>() {9600, 19200, 38400, 57600, 115200};
    }
    
    public Task ScanPorts()
    {
        Ports =  _serialService.ScanPortsAsync().GetAwaiter().GetResult();
        OnPropertyChanged(nameof(Ports));
        return Task.CompletedTask;
    }
    
    public Task SetBaudRate(int baudRate)
    {
        _serialService.ConfigureBaudRate(baudRate);
        return Task.CompletedTask;
    }
    public Task ConfigurePort(string portName)
    {
        _serialService.ConfigurePort(portName);
        return Task.CompletedTask;
    }
    
    public Task Connect()
    {
        _serialService.Connect();
        return Task.CompletedTask;
    }
}