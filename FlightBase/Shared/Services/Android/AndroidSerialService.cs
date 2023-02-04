using System.IO.Ports;
using System.Runtime.Versioning;
using FlightBase.Shared.Services.Common;

namespace FlightBase.Shared.Services.Android;

public class AndroidSerialService : ISerialService
{
    private SerialPort _port;

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public async Task<List<string>> ScanPortsAsync()
    {
        var ports = new List<string>() {"COM1", "COM2", "COM3", "COM4"};
        return ports;
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public Task<bool> Connect(string portName)
    {
        throw new NotImplementedException();
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public Task<bool> Disconnect()
    {
        throw new NotImplementedException();
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public Task<bool> Send(string message)
    {
        throw new NotImplementedException();
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public Task<string> Read()
    {
        throw new NotImplementedException();
    }
}