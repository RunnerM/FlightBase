using System.IO.Ports;
using System.Runtime.Versioning;
using FlightBase.Shared.Services.Common;

namespace FlightBase.Shared.Services.Windows;

public class WindowsSerialService : SerialService
{
    private SerialPort _port;
#pragma warning disable CA1416
    public WindowsSerialService()
    {
        _port= new SerialPort();
    }
    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override async Task<List<string>> ScanPortsAsync()
    {
        var ports = SerialPort.GetPortNames();
        return ports.Length > 0 ? ports.ToList() : new List<string>();
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override Task<bool> Connect()
    {
        _port = new SerialPort(_portName, _baudRate, Parity.None, 8, StopBits.One);
        _port.Open();
        return Task.FromResult(true);
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override Task<bool> Disconnect()
    {
        _port.Close();
        return Task.FromResult(true);
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override Task<bool> Send(string message)
    {
        _port.WriteLine(message);
        return Task.FromResult(true);
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public override Task<string> Read()
    {
        return Task.FromResult(_port.ReadLine());
    }

#pragma warning restore CA1416
}