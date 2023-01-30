using FlightBase.Shared.Services;

namespace FlightBase.Shared.ViewModel;

public class SettingsViewModel
{
    private readonly ISerialService _serialService;
    
    public SettingsViewModel(ISerialService serialService)
    {
        _serialService = serialService;
    }
}