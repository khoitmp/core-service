namespace Core.Api.Models;

public class Device
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }

    public Device(string id, string name, int value)
    {
        Id = id;
        Name = name;
        Value = value;
    }
}