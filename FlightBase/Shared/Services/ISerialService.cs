namespace FlightBase.Shared.Services;

public interface ISerialService
{
    public Task<List<string>> ScanPortsAsync();
    public Task<bool> Connect(string portName);
    public Task<bool> Disconnect();
    public Task<bool> Send(string message);
    public Task<String> Read();

}