using System.IO.Ports;
using System.Runtime.Versioning;
using FlightBase.Shared.Services.Common;

namespace FlightBase.Shared.Services.Windows;

public class WindowsSerialService : ISerialService
{

    private SerialPort _port;
#pragma warning disable CA1416
    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public async Task<List<string>> ScanPortsAsync()
    {
        if (DeviceInfo.Current.Platform != DevicePlatform.WinUI)
            return DeviceInfo.Current.Platform == DevicePlatform.Android
                ? new List<string>() {"COM1", "COM2", "COM3", "COM4"}
                : new List<string>();
        var ports = SerialPort.GetPortNames();
        return ports.Length > 0 ? ports.ToList() : new List<string>();
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public Task<bool> Connect(string portName)
    {
        _port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
        _port.Open();
        return Task.FromResult(true);
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public Task<bool> Disconnect()
    {
        _port.Close();
        return Task.FromResult(true);
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public Task<bool> Send(string message)
    {
        _port.WriteLine(message);
        return Task.FromResult(true);
    }

    [UnsupportedOSPlatformGuard("ios")]
    [UnsupportedOSPlatformGuard("macOS")]
    public Task<string> Read()
    {
        return Task.FromResult(_port.ReadLine());
    }

#pragma warning restore CA1416
}