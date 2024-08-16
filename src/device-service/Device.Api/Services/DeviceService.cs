namespace Device.Api.Services;

public class DeviceService
{
    private readonly IConfiguration _configuration;
    private readonly int _value;

    public DeviceService(IConfiguration configuration)
    {
        _configuration = configuration;
        _value = Convert.ToInt32(_configuration["Value"] ?? "0");
    }

    public Task<List<DeviceModel>> GetDevicesAsync()
    {
        var devices = new List<DeviceModel>()
        {
            new DeviceModel("device1", "Device 1", CalculateValue(1)),
            new DeviceModel("device2", "Device 2", CalculateValue(2)),
            new DeviceModel("device3", "Device 3", CalculateValue(3))
        };
        return Task.FromResult(devices);
    }

    public int CalculateValue(int value)
    {
        return value * _value;
    }
}