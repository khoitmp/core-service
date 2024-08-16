namespace Device.Api.Models;

public class DeviceModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }

    public DeviceModel(string id, string name, int value)
    {
        Id = id;
        Name = name;
        Value = value;
    }
}