using System.IO.Ports;

namespace FlightBase.Shared.Services.Common;

public abstract class SerialService : ISerialService
{
    protected int _baudRate;
    protected string _portName;
    public abstract bool IsConnected { get; }
    public abstract Task<List<string>> ScanPortsAsync();
    public abstract Task<bool> Connect();
    public abstract Task<bool> Disconnect();
    public abstract Task<bool> Send(string message);
    public abstract Task<string> Read();

    public Task ConfigureBaudRate(int baudRate)
    {
        _baudRate = baudRate;
        return Task.CompletedTask;
    }
    
    public Task ConfigurePort(string portName)
    {
        _portName = portName;
        return Task.CompletedTask;
    }

    public abstract void AssignSerialHandler(SerialDataReceivedEventHandler handler);
    bool ISerialService.IsConnected() => IsConnected;
}