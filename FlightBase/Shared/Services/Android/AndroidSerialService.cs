using System.IO.Ports;
using System.Runtime.Versioning;
using FlightBase.Shared.Services.Common;

namespace FlightBase.Shared.Services.Android;

public class AndroidSerialService : SerialService
{
    private SerialPort _port;

    public override bool IsConnected => _port.IsOpen;

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override async Task<List<string>> ScanPortsAsync()
    {
        var ports = new List<string>() {"COM1", "COM2", "COM3", "COM4"};
        return ports;
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override Task<bool> Connect()
    {
        throw new NotImplementedException();
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override Task<bool> Disconnect()
    {
        throw new NotImplementedException();
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override Task<bool> Send(string message)
    {
        throw new NotImplementedException();
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override Task<string> Read()
    {
        throw new NotImplementedException();
    }

    public override void AssignSerialHandler(SerialDataReceivedEventHandler handler)
    {
        throw new NotImplementedException();
    }
}