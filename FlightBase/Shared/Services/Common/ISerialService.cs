using System.IO.Ports;

namespace FlightBase.Shared.Services.Common;

public interface ISerialService
{
    public Task<List<string>> ScanPortsAsync();
    public Task<bool> Connect();
    public Task<bool> Disconnect();
    public Task<bool> Send(string message);
    public Task<String> Read();
    public Task ConfigureBaudRate(int baudRate);
    public Task ConfigurePort(string portName);

    public void AssignSerialHandler(SerialDataReceivedEventHandler handler);
    public bool IsConnected();

}