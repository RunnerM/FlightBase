using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.Versioning;
using FlightBase.Shared.Services.Common;

namespace FlightBase.Shared.Services.Windows;

public class WindowsSerialService : SerialService
{
    private SerialPort _port;
    public static List<SerialDataReceivedEventHandler> DataReceivedHandlers { get; set; }



#pragma warning disable CA1416
    public WindowsSerialService()
    {
        DataReceivedHandlers = new List<SerialDataReceivedEventHandler>();
    }

    public override bool IsConnected => _port?.IsOpen ?? false;

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
        try
        {
            _port = new SerialPort(_portName, _baudRate, Parity.None, 8, StopBits.One);
            foreach (var handler in DataReceivedHandlers)
            {
                _port.DataReceived += handler;
            }
            _port.DataReceived += (sender, args) => Debug.WriteLine("Data received on: "+_portName+" "+_baudRate);
            _port.Open();
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
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
        _port.DataReceived += (sender, args) =>
        {
            if (CanRead())
                _port.ReadLine();
        };
        if (CanRead())
            return Task.FromResult(_port.ReadLine());
        return Task.FromResult(string.Empty);
    }

    public override void AssignSerialHandler(SerialDataReceivedEventHandler handler)
    {
        DataReceivedHandlers.Add(handler);
    }

    private bool CanRead() => _port.IsOpen && _port.BytesToRead > 0;

#pragma warning restore CA1416
}