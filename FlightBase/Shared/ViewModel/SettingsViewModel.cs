using FlightBase.Shared.Services;

namespace FlightBase.Shared.ViewModel;

public class SettingsViewModel
{
    private readonly ISerialService _serialService;
    public List<string> Ports { get; set; }
    
    public SettingsViewModel(ISerialService serialService)
    {
        _serialService = serialService;
        ScanPorts();
    }
    
    public Task ScanPorts()
    {
        Ports =  _serialService.ScanPortsAsync().GetAwaiter().GetResult();
        return Task.CompletedTask;
    }
}